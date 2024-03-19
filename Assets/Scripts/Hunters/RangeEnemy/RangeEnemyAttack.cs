using System;
using System.Collections;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour, IAttackable
{
    [Header("Prefabs"), SerializeField] private GameObject _bulletPrefab;

    [Space, Header("Properties")]
    [SerializeField] private float _cooldownBTWAttack;

    private Coroutine _coroutine;

    private Vector3 _targetPosition;

    public void AttackUpdate()
    {

    }

    public void StartAttack()
    {
        _coroutine = StartCoroutine(Attacking());
    }

    public void StopAttack()
    {
        StopCoroutine(_coroutine);
    }

    private void Attack()
    {

    }

    private void GetTargetRotation()
    {

    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(_cooldownBTWAttack);
        }
    }
}
