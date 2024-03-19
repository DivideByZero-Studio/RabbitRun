using UnityEngine;

public class EnemyBehaviourAttack : IState
{
    private MeleeEnemyAttack _attacker;

    public EnemyBehaviourAttack(MeleeEnemyAttack attacker)
    {
        _attacker = attacker;
    }

    public void Enter()
    {
        Debug.Log($"Behaviour: {nameof(EnemyBehaviourAttack)}");
        _attacker.StartAttack();
    }

    public void Exit()
    {
        _attacker.StopAttack();
    }

    public void Update()
    {
        _attacker.AttackUpdate();
    }
}
