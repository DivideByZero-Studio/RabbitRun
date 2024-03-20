using UnityEngine;

public class EnemyLookingPlayer : MonoBehaviour
{
    // Reorganize links
    [SerializeField] private Transform _target;

    [SerializeField] private SpriteRenderer _directionSpriteRenderer;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _directionSpriteRenderer.enabled = false;
    }

    private void Update()
    {
        _transform.right = _target.position - _transform.position;
    }

    private void OnEnable()
    {
        _directionSpriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        _directionSpriteRenderer.enabled = false;
    }
}
