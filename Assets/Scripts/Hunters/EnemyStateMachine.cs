using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Dictionary<Type, IState> _behavioursMap;
    private IState _currentBehaviour;

    private EnemyMovement _movement;

    [Header("AI Triggers")]
    [SerializeField] private EnemyTriggerPlayer _detectionTrigger;
    [SerializeField] private EnemyTriggerPlayer _attackTrigger;

    [Space, Header("Attack module")]
    [SerializeField] private MeleeEnemyAttack _enemyAttack;

    private void Awake()
    {
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
        _behavioursMap[typeof(EnemyBehaviourAttack)] = new EnemyBehaviourAttack(_enemyAttack);
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
        _attackTrigger.OnDetectedPlayer += SetBehaviourAttack;
        _attackTrigger.OnUndetectedPlayer += SetBehaviourChasing;

        _detectionTrigger.OnDetectedPlayer += SetBehaviourChasing;
        _detectionTrigger.OnUndetectedPlayer += SetBehaviourIdle;
    }

    private void Unsubcribe()
    {
        _attackTrigger.OnDetectedPlayer -= SetBehaviourAttack;
        _attackTrigger.OnUndetectedPlayer -= SetBehaviourChasing;

        _detectionTrigger.OnDetectedPlayer -= SetBehaviourChasing;
        _detectionTrigger.OnUndetectedPlayer -= SetBehaviourIdle;
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
