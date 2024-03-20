using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out var player))
        {
            player.TakeDamage();
        }
        Destroy(gameObject);
    }
}
