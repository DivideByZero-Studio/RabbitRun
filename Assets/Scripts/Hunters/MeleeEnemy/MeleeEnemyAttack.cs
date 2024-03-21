using System.Collections;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour, IAttackable
{
    // Reorganize links!
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _enemyTransform;

    [Space, SerializeField] private float _attackTime;
    [SerializeField] private float _cooldownBTWAttacks;

    private CircleCollider2D _attackZone;

    private Vector3 _jumpPosition;
    private Vector3 _target;
    
    private bool _prepared;

    private float _jumpProgress = 0f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _attackZone = GetComponent<CircleCollider2D>();
        _attackZone.enabled = false;
    }

    public void AttackUpdate()
    {
        if (_prepared)
        {
            _jumpProgress += Time.deltaTime * _attackTime;
            _enemyTransform.position = Vector3.Lerp(_jumpPosition, _target, _jumpProgress);
        }
    }

    public void StartAttack()
    {
        _coroutine = StartCoroutine(Attacking());
    }

    public void StopAttack()
    {
        StopAllCoroutines();
    }

    private void GetTargetPosition()
    {
        _target = _player.position;
    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(_cooldownBTWAttacks - 0.2f);
            _jumpProgress = 0f;
            _prepared = true;
            _jumpPosition = _enemyTransform.position;
            GetTargetPosition();
            yield return new WaitForSeconds(_attackTime);
            _attackZone.enabled = true;
            yield return new WaitForSeconds(0.2f);
            _attackZone.enabled = false;
            _prepared = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out var player))
        {
            player.TakeDamage();
        }
    }
}
