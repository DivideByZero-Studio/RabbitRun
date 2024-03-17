using UnityEngine;

public class EnemyBehaviourIdle : IState
{
    public void Enter()
    {
        Debug.Log($"Behaviour: {nameof(EnemyBehaviourIdle)}");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
