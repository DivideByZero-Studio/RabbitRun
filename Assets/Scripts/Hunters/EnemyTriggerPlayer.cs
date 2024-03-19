using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyTriggerPlayer : MonoBehaviour
{
    public event Action OnDetection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            OnDetection?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            OnDetection?.Invoke();
        }
    }
}
