using UnityEngine;

public class Sweep : MonoBehaviour
{
    private float _turnRotationMult;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private Quaternion _startRotation;
    private Vector3 _startPosition;
    private float _position;
    private Transform _transform;

    public float roadWidth;
    public float turnMult;
    public float verticalMult;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX =  Mathf.Clamp(_lastFrameFingerPositionX - Input.mousePosition.x,-roadWidth,roadWidth)/10;
            VerticalMovement(verticalMult);
            Turn(turnMult);
            if (Mathf.Abs(_moveFactorX) >= 6)
            {
                TurnReset();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
            TurnReset();
        }
    }

    private void Turn(float multiplier)
    {
        var rotation = _transform.rotation;
        _transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, -_moveFactorX * multiplier);
    }

    private void TurnReset()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, _startRotation, 0.2f);
    }

    private void VerticalMovement(float multiplier)
    {
        transform.localPosition = new Vector3(0, Mathf.Clamp(-_moveFactorX*multiplier,-roadWidth,roadWidth),0);
    }
    
}
