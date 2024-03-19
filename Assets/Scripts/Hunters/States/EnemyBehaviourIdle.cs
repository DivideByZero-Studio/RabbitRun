using UnityEngine;
public class EnemyBehaviourIdle : IState
{
    private EnemyMovement _movement;
    public EnemyBehaviourIdle(EnemyMovement movement)
    {
        _movement = movement;
    }

    public void Enter()
    {
        Debug.Log($"Behaviour: {nameof(EnemyBehaviourIdle)}");
        _movement.StartCoroutine(_movement.UpdatingTargetPosition());
    }

    public void Exit()
    {
        _movement.StopPatrol();
    }

    public void Update()
    {
        _movement.Patrol();
    }
}
