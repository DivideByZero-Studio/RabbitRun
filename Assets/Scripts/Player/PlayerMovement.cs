using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform directionPointer;
    [SerializeField] private float jumpDuration; //in seconds
    [SerializeField, Min(1f)] private float jumpStepMultiplier;

    public event Action Jumped;
    public event Action Landed;
    
    private void Jump()
    {
        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine()
    {
        Jumped?.Invoke();
        float time = jumpDuration;
        while (time > 0)
        {
            transform.Translate(Time.deltaTime * jumpStepMultiplier * directionPointer.transform.right);
            time -= Time.deltaTime;
            yield return null;
        }
        Landed?.Invoke();
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
