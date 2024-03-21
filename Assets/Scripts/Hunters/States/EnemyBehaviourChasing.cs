using UnityEngine;

public class EnemyBehaviourChasing : IState
{
    private EnemyMovement _movement;
    public EnemyBehaviourChasing(EnemyMovement movement)
    {
        _movement = movement;
    }
    public void Enter()
    {
        Debug.Log($"Behaviour: {nameof(EnemyBehaviourChasing)}");
        _movement.StartMove();
    }

    public void Exit()
    {
        _movement.StopMove();
    }

    public void Update()
    {
        _movement.Chase();
    }
}
