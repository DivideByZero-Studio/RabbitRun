using System.Collections;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyMovement
{
    // Reorganize links!
    [SerializeField] private Transform _playerTransform;

    [Space, Header("Chasing properties")]
    [SerializeField] private float _chasingSpeed;

    [Space, Header("Patrol properties")]
    [SerializeField] private float _patrolLength;
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _patrolTimer;

    private Transform _transform;

    private Vector3 _targetPosition;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void Move()
    {

    }

    public void Chase()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _playerTransform.position, _chasingSpeed * Time.deltaTime);
    }

    public void Patrol()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _patrolSpeed * Time.deltaTime);
    }

    private Vector2 GetRandomNormalizedVector()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    public IEnumerator UpdatingTargetPosition()
    {
        while (true)
        {
            var direction = GetRandomNormalizedVector();
            _targetPosition = _transform.position + new Vector3(direction.x, direction.y, 0) * _patrolLength;
            yield return new WaitForSeconds(_patrolTimer);
        }   
    }

    public void StartPatrol()
    {
        StartCoroutine(UpdatingTargetPosition());
    }
}
