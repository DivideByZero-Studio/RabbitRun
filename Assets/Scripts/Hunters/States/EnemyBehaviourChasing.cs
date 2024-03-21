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
    }

    public void Exit()
    {

    }

    public void Update()
    {
        _movement.Chase();
    }
}
