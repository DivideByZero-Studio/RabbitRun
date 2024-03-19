using System.Collections;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour, IAttackable
{
    // Reorganize links!
    [SerializeField] private Transform _player;

    [Space, SerializeField] private float _attackTime;
    [SerializeField] private float _cooldownBTWAttacks;

    private CircleCollider2D _attackZone;

    private Vector3 _jumpPosition;
    private Vector3 _target;
    private Transform _transform;

    private bool _prepared;

    private float _jumpProgress = 0f;

    private void Awake()
    {
        _attackZone = GetComponent<CircleCollider2D>();
        _attackZone.enabled = false;
        _transform = transform;
    }

    public void AttackUpdate()
    {
        if (_prepared)
            _jumpProgress += Time.deltaTime * _attackTime;
            _transform.position = Vector3.Lerp(_jumpPosition, _target, _jumpProgress);
    }

    public void StartAttack()
    {
        StartCoroutine(Attacking());
    }

    private void GetTargetPosition()
    {
        _target = _player.position;
    }

    private IEnumerator Attacking()
    {
        while (true)
        {
            _jumpProgress = 0f;
            _prepared = true;
            _jumpPosition = _transform.position;
            GetTargetPosition();
            yield return new WaitForSeconds(_attackTime);
            _attackZone.enabled = true;
            yield return new WaitForSeconds(0.2f);
            _attackZone.enabled = false;
            _prepared = false;
            yield return new WaitForSeconds(_cooldownBTWAttacks - 0.2f);
        }
    }

    public void StopAttack()
    {
        StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Change Try to get class
        if (collision.TryGetComponent<PlayerMovement>(out var player))
        {
            Debug.Log("Attacked");
        }
    }
}
