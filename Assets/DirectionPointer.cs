using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationAngle;
    
    private bool _canRotate = true;
    private float _angleZ;
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
            _angleZ = transform.localRotation.eulerAngles.z;
            float allowedAngle = rotationAngle / 2;
            if ((_angleZ > allowedAngle) && (_angleZ < 360 - allowedAngle))
            {
                _rotationDirection *= -1;
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * _rotationDirection * 2);
            }

            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * _rotationDirection);
        }
    }

    private void StopRotation()
    {
        transform.Rotate(0, 0, -_angleZ);
        _canRotate = false;
    }
    
    private void ContinueRotation()
    {
        _rotationDirection *= -1;
        _canRotate = true;
    }
}
