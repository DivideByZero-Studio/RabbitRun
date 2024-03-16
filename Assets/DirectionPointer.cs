using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationAngle;
    
    private bool _canRotate = true;
    private int _rotationDirection = 1;

    private void Start()
    {
        player.Jumped += StopRotation;
        player.Landed += ContinueRotation;
    }

    private void Update()
    {
        if (_canRotate)
        {
            float angleZ = transform.rotation.eulerAngles.z;
            float allowedAngle = rotationAngle / 2;
            if ((angleZ > allowedAngle) && (angleZ < 360-allowedAngle))
                _rotationDirection *= -1;
            
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * _rotationDirection);
        }
    }

    private void StopRotation()
    {
        _canRotate = false;
    }
    
    private void ContinueRotation()
    {
        _rotationDirection *= -1;
        _canRotate = true;
    }
}
