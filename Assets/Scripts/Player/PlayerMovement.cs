using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerVisuals playerVisuals;
    
    [SerializeField] private DirectionPointer directionPointer;
    [SerializeField] private float jumpDuration; //in seconds
    [SerializeField, Min(1f)] private float jumpStepMultiplier;
    
    [SerializeField] private float jumpCooldown;
    [SerializeField] private int jumpsCapacity;
    [SerializeField] private float jumpReloadTime;
    private bool _canJump = true;
    private bool _isReloading;
    private int _jumpsLeft;

    private Vector3 _jumpDirection { get; set; }
    
    public event Action Jumped;
    public event Action Landed;

    public event Action<float> JumpBeganReload;
    
    private void Awake()
    {
        _jumpsLeft = jumpsCapacity;
    }

    private void Jump()
    {
        if (_canJump == false || _jumpsLeft <= 0) return;
        
        StartCoroutine(JumpRoutine());
    }

    private void Update()
    {
        if (_jumpsLeft < jumpsCapacity && !_isReloading)
        {
            StartCoroutine(ReloadJump());
        }
    }

    private IEnumerator JumpRoutine()
    {
        Jumped?.Invoke();
        
        _canJump = false;
        _jumpsLeft--;
        
        playerVisuals.SetRotation(directionPointer.transform.rotation);
        _jumpDirection = directionPointer.transform.right;

        float time = jumpDuration;
        while (time > 0)
        {
            transform.Translate(Time.deltaTime * jumpStepMultiplier * _jumpDirection);
            time -= Time.deltaTime;
            yield return null;
        }
        
        Landed?.Invoke();
        
        _canJump = true;

        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        _canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        _canJump = true;
    }

    private IEnumerator ReloadJump()
    {
        _isReloading = true;
        
        JumpBeganReload?.Invoke(jumpReloadTime);

        yield return new WaitForSeconds(jumpReloadTime);
        _jumpsLeft += 1;

        _isReloading = false;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (TryGetComponent(out Obstacle obstacle))
        {
            var normal = other.GetContact(0).normal;
            var reflectDirection = Vector2.Reflect(_jumpDirection, normal);
            _jumpDirection = reflectDirection;
        }
    }

    private void OnEnable()
    {
        GameInput.Instance.JumpButtonPressed += Jump;
    }
    
    private void OnDisable()
    {
        GameInput.Instance.JumpButtonPressed -= Jump;
    }
}
