using System.Collections;
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

    [Space, Header("SFXs")]
    [SerializeField] private AudioClip _stepSFX;

    private Transform _transform;

    private Vector3 _targetPosition;

    private const float _timeToStep = 0.5f;

    private void Awake()
    {
        _transform = transform;
    }

    public void Move()
    {

    }

    public void StartMove()
    {
        StartCoroutine(MakeStepsSFX());
    }

    public void StopMove()
    {
        StopAllCoroutines();
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

    public void StopPatrol()
    {
        StopAllCoroutines();
    }

    private IEnumerator MakeStepsSFX()
    {
        PlayRandomPitchedStepSFX();
        yield return new WaitForSeconds(_timeToStep);
    }

    private void PlayRandomPitchedStepSFX()
    {
        AudioManager.Instance.PlayRandomPitchedSFX(_stepSFX);
    }
}
