using UnityEngine;

public class EnemyBehaviourChasing : IState
{
    public void Enter()
    {
        Debug.Log($"Behaviour: {nameof(EnemyBehaviourChasing)}");
    }

    public void Exit()
    {

    }

    public void Update()
    {

    }
}
