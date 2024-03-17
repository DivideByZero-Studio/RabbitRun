using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyTriggerPlayer : MonoBehaviour
{
    public Action OnDetectedPlayer;
    public Action OnUndetectedPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            OnDetectedPlayer?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            OnUndetectedPlayer?.Invoke();
        }
    }
}
