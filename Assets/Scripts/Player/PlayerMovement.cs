using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerVisuals playerVisuals;
    
    [SerializeField] private DirectionPointer directionPointer;
    [SerializeField] private float jumpDuration; //in seconds
    [SerializeField, Min(1f)] private float jumpStepMultiplier;
    
    public event Action Jumped;
    public event Action Landed;

    private Vector3 _jumpDirection { get; set; }
    
    private void Jump()
    {
        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine()
    {
        Jumped?.Invoke();
        
        playerVisuals.SetRotation(directionPointer.transform.rotation);
        _jumpDirection = directionPointer.transform.right;

        float time = jumpDuration;
        while (time > 0)
        {
            Debug.Log(_jumpDirection);
            transform.Translate(Time.deltaTime * jumpStepMultiplier * _jumpDirection);
            time -= Time.deltaTime;
            yield return null;
        }
        
        Landed?.Invoke();
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
