using System;
using System.Collections;
using UnityEngine;

public class RangeEnemyAttack : MonoBehaviour, IAttackable
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _bulletPrefab;

    [Space, Header("Properties")]
    [SerializeField] private float _cooldownBTWAttack;
    [SerializeField] private Transform _bulletSpawnDot;
    private Coroutine _coroutine;

    private Vector3 _targetPosition;

    private EnemyLookingPlayer _enemyLookingPlayer;

    private void Awake()
    {
        _enemyLookingPlayer = GetComponent<EnemyLookingPlayer>();
    }

    private void Start()
    {
        _enemyLookingPlayer.enabled = false;
    }

    public void AttackUpdate()
    {

    }

    public void StartAttack()
    {
        _enemyLookingPlayer.enabled = true;
        _coroutine = StartCoroutine(Attacking());
    }

    public void StopAttack()
    {
        _enemyLookingPlayer.enabled = false;
        StopCoroutine(_coroutine);
    }

    private void Attack()
    {
        Instantiate(_bulletPrefab, _bulletSpawnDot.position, transform.rotation);
    }

    private void GetTargetRotation()
    {

    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cooldownBTWAttack);
            Attack();
        }
    }
}
