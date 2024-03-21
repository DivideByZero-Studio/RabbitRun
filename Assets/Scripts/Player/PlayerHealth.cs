using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action Dead;
    [SerializeField] private int _maxHealth;

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
        SceneLoader.ReloadScene();
        _movement.enabled = false;
    }

    private void OnEnable()
    {
        Dead += OnDead;
        _health = _maxHealth;
    }

    private void OnDisable()
    {
        Dead -= OnDead;
    }
}
