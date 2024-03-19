using UnityEngine;

public class EnemyBehaviourAttack : IState
{
    private IAttackable _attacker;

    public EnemyBehaviourAttack(IAttackable attacker)
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
