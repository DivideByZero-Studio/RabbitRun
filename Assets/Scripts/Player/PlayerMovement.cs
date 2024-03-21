using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerVisuals playerVisuals;
    
    [SerializeField] private DirectionPointer directionPointer;
    [SerializeField] private float jumpDuration; //in seconds
    [SerializeField, Min(1f)] private float jumpStepMultiplier;
    
    [SerializeField] private float jumpCooldown;
    [SerializeField] private int jumpsCapacity;
    [SerializeField] private float jumpReloadTime;

    [Space, Header("SFXs")]
    [SerializeField] private AudioClip[] _jumpSFXs;

    private bool _canJump = true;
    private bool _isReloading;
    private int _jumpsLeft;

    private Vector3 _jumpDirection { get; set; }
    
    public event Action Jumped;
    public event Action Landed;

    public event Action JumpReloadStarted;
    public event Action<float> JumpReloadUpdate;
    public event Action JumpReloadDone;
    
    private void Awake()
    {
        _jumpsLeft = jumpsCapacity;
    }

    private void Jump()
    {
        if (_canJump == false || _jumpsLeft <= 0) return;

        PlayRandomJumpSFX();
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
        JumpReloadStarted?.Invoke();
        Jumped?.Invoke();

        _jumpsLeft--;
        _canJump = false;

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

        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(jumpCooldown);
        _canJump = true;
    }

    private IEnumerator ReloadJump()
    {
        _isReloading = true;

        float time = jumpReloadTime;
        float step = 1 / time;
        float progress = 0;
        
        while (time > 0)
        {
            progress += step * Time.deltaTime;
            JumpReloadUpdate?.Invoke(progress);
            time -= Time.deltaTime;
            yield return null;
        }
        JumpReloadDone?.Invoke();
        _jumpsLeft += 1;

        _isReloading = false;
    }

    private void OnEnable()
    {
        GameInput.Instance.JumpButtonPressed += Jump;
    }
    
    private void OnDisable()
    {
        GameInput.Instance.JumpButtonPressed -= Jump;
    }

    private void PlayRandomJumpSFX()
    {
        AudioManager.Instance.PlayRandomPitchedSFX(_jumpSFXs[Random.Range(0, _jumpSFXs.Length - 1)]);
    }
}
