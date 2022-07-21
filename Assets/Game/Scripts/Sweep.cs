using UnityEngine;
using DG.Tweening;
public class Sweep : MonoBehaviour
{
    private float _turnRotationMult;
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    private Vector3 _startPosition;
    private float _position;
    private Transform _transform;

    public float roadWidth;
    public float turnMult;
    public float verticalMult;
    public float sweepMult;
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
            _moveFactorX =  Mathf.Clamp((_lastFrameFingerPositionX - Input.mousePosition.x)/sweepMult,-roadWidth,roadWidth);
            VerticalMovement(verticalMult);
            Turn(turnMult);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            TurnReset(0.5f);
            _moveFactorX = 0f;
        }
    }

    private void Turn(float multiplier)
    {
        var rotation = _transform.rotation;
        _transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, -_moveFactorX * multiplier);
        Debug.Log(_transform.rotation);
    }

    private void TurnReset(float time)
    {
        _transform.DORotate(new Vector3(0, 0,0), time, RotateMode.Fast);
    }

    private void VerticalMovement(float multiplier)
    {
        transform.localPosition = new Vector3(0, Mathf.Clamp(transform.localPosition.y-_moveFactorX*multiplier,-roadWidth,roadWidth),0);
    }
    
}
