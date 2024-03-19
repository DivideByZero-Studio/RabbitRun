using System;
using UnityEngine;

public class InteractableTriggerArea : MonoBehaviour
{
    public event Action TriggerEntered;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            TriggerEntered?.Invoke();
        }
    }
}
