using UnityEngine;

public class EnemyLookingPlayer : MonoBehaviour
{
    // Reorganize links
    [SerializeField] private Transform _target;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.rotation = Quaternion.LookRotation(_target.position - _transform.position);
    }
}
