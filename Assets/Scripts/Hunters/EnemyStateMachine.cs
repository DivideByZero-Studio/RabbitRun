using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Dictionary<Type, IState> _behavioursMap;
    private IState _currentBehaviour;

    private EnemyMovement _movement;

    [Header("Distance to player module")]
    [SerializeField] private EnemyDistanceToPlayer _enemyDistanceToPlayer;

    [Space, Header("Attack module")]
    [SerializeField] private GameObject _enemyAttack;
    private IAttackable _attacker;

    private void Awake()
    {
        _attacker = _enemyAttack.GetComponent<IAttackable>();
        Debug.Log(nameof(_attacker));
        _movement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        Subscribe();
        InitBehaviours();
        SetBehaviourByDefault();
    }

    private void InitBehaviours()
    {
        _behavioursMap = new Dictionary<Type, IState>();
        _behavioursMap[typeof(EnemyBehaviourIdle)] = new EnemyBehaviourIdle(_movement);
        _behavioursMap[typeof(EnemyBehaviourChasing)] = new EnemyBehaviourChasing(_movement);
        _behavioursMap[typeof(EnemyBehaviourAttack)] = new EnemyBehaviourAttack(_attacker);
    }

    private void SetBehaviour(IState newBehaviour)
    {
        if (newBehaviour == _currentBehaviour)
            return;
        _currentBehaviour?.Exit();
        _currentBehaviour = newBehaviour;
        _currentBehaviour.Enter();
    }

    private IState GetBehaviour<T>() where T : IState
    {
        var type = typeof(T);
        return _behavioursMap[type];
    }

    private void SetBehaviourByDefault()
    {
        var defaultBehaviour = GetBehaviour<EnemyBehaviourIdle>();
        SetBehaviour(defaultBehaviour);
    }

    private void Update()
    {
        _currentBehaviour?.Update();
    }

    private void SetBehaviourIdle()
    {
        var behaviour = GetBehaviour<EnemyBehaviourIdle>();
        SetBehaviour(behaviour);
    }

    private void SetBehaviourChasing()
    {
        var behaviour = GetBehaviour<EnemyBehaviourChasing>();
        SetBehaviour(behaviour);
    }

    private void SetBehaviourAttack()
    {
        var behaviour = GetBehaviour<EnemyBehaviourAttack>();
        SetBehaviour(behaviour);
    }

    private void Subscribe()
    {
        _enemyDistanceToPlayer.OnIdleDistance += SetBehaviourIdle;
        _enemyDistanceToPlayer.OnChaseDistance += SetBehaviourChasing;
        _enemyDistanceToPlayer.OnAttackDistance += SetBehaviourAttack;
    }

    private void Unsubcribe()
    {
        _enemyDistanceToPlayer.OnIdleDistance -= SetBehaviourIdle;
        _enemyDistanceToPlayer.OnChaseDistance -= SetBehaviourChasing;
        _enemyDistanceToPlayer.OnAttackDistance -= SetBehaviourAttack;
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubcribe();
    }
}
