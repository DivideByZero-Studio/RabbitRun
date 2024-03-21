using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private DirectionPointerVisuals pointerVisuals;
    
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationAngle;
    
    private bool _canRotate = true;
    private float _angleZ;
    private float _difAngle;
    private int _rotationDirection = 1;

    private void Start()
    {
        _difAngle = transform.rotation.eulerAngles.z;
        player.Jumped += StopRotation;
        player.Landed += ContinueRotation;
    }

    private void Update()
    {
        if (_canRotate)
        {
            _angleZ = transform.localRotation.eulerAngles.z;
            float allowedAngle = rotationAngle / 2;

            var maxAngle = (allowedAngle + _difAngle) % 360;
            var minAngle = (360 - allowedAngle + _difAngle) % 360;

            if (maxAngle < 180 && minAngle > 180)
            {
                if ((_angleZ <= 360 && _angleZ > minAngle) || (_angleZ >= 0 && _angleZ < maxAngle))
                {
                    
                }
                else
                {
                    ChangeRotationDirection();
                }
            }
                
            else if (_angleZ < minAngle || _angleZ > maxAngle)
            {
                ChangeRotationDirection();
            }
            
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * _rotationDirection);
        }
    }

    private void ChangeRotationDirection()
    {
        _rotationDirection *= -1;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * _rotationDirection * 2);
    }

    private void SetBoundsForRotation()
    {
        _difAngle = _angleZ;
    }
    
    private void StopRotation()
    {
        SetBoundsForRotation();
        pointerVisuals.MakeNotAvailable();
        _canRotate = false;
    }
    
    private void ContinueRotation()
    {
        pointerVisuals.MakeAvailable();
        _rotationDirection *= -1;
        _canRotate = true;
    }
}
