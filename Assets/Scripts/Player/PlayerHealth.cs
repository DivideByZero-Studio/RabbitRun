using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action Dead;
    [SerializeField] private int _maxHealth;

    [SerializeField] private AudioClip _deathClip;
    public int Health => _health;

    private int _health;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage()
    {
        _health -= 1;
        if (_health <= 0)
        {
            Dead?.Invoke();
        }
    }

    private void OnDead()
    {
        _movement.enabled = false;
    }

    private void PlayDeadSFX()
    {
        AudioManager.Instance.PlaySFX(_deathClip);
    }

    private void OnEnable()
    {
        Dead += OnDead;
        Dead += PlayDeadSFX;
        _health = _maxHealth;
    }

    private void OnDisable()
    {
        Dead -= OnDead;
        Dead -= PlayDeadSFX;
    }
}
