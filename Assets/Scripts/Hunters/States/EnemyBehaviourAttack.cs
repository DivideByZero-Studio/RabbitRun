using UnityEngine;

public class EnemyBehaviourAttack : IState
{
    public void Enter()
    {
        Debug.Log($"Behaviour: {nameof(EnemyBehaviourAttack)}");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
