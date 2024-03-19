using System;
using UnityEngine;

public class EnemyDistanceToPlayer : MonoBehaviour
{
    //  Actions for switch behaviours
    public event Action OnIdleDistance;
    public event Action OnChaseDistance;
    public event Action OnAttackDistance;

    // Reorganize links
    [SerializeField] private Transform _playerTransform;

    [Space, Header("Triggers")]
    [SerializeField] private EnemyTriggerPlayer _chasingTrigger;
    [SerializeField] private EnemyTriggerPlayer _attackTrigger;

    [Space, Header("Colliders")]
    [SerializeField] private CircleCollider2D _chasingCollider;
    [SerializeField] private CircleCollider2D _attackCollider;
    [SerializeField] private float _colliderOffset;

    private float _chaseDistance;
    private float _attackDistance;

    private void Awake()
    {
        _chaseDistance = _chasingCollider.radius + _colliderOffset;
        _attackDistance = _attackCollider.radius + _colliderOffset;
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(_playerTransform.position, transform.position);
    }

    private void TryToSwitchBehaviour()
    {
        float distance = GetDistanceToPlayer();

        if (_attackDistance < distance && distance <= _chaseDistance)
        {
            OnChaseDistance?.Invoke();
            return;
        }
        if (distance <= _attackDistance)
        {
            OnAttackDistance?.Invoke();
            return;
        }
        OnIdleDistance?.Invoke();
    }

    private void Subscribe()
    {
        _chasingTrigger.OnDetection += TryToSwitchBehaviour;
        _attackTrigger.OnDetection += TryToSwitchBehaviour;
    }

    private void Unsubscribe()
    {
        _chasingTrigger.OnDetection -= TryToSwitchBehaviour;
        _attackTrigger.OnDetection -= TryToSwitchBehaviour;
    }

    private void OnDisable()
    {
        Unsubscribe();
    }
}
