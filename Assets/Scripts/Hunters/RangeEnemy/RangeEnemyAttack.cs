using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RangeEnemyAttack : MonoBehaviour, IAttackable
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _bulletPrefab;

    [Space, Header("Properties")]
    [SerializeField] private float _cooldownBTWAttack;
    [SerializeField] private Transform _bulletSpawnDot;

    [Space, Header("Shot SFX")]
    [SerializeField] private AudioClip[] _shotSFXs;
    private Coroutine _coroutine;

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
        PlayRandomShotSFX();
    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cooldownBTWAttack);
            Attack();
        }
    }

    private void PlayRandomShotSFX()
    {
        AudioManager.Instance.PlaySFX(_shotSFXs[Random.Range(0, _shotSFXs.Length - 1)]);
    }
}
