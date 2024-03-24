using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _cubeMaxPositionX;

    public delegate void CubeOnClickUp();
    public CubeOnClickUp OnClickUpEvent;

    private Cube _baseCube;
    private Vector3 _cubePosition;
    private bool _isPointerDown;
    private bool _canMove;

    public Cube BaseCube { set { _baseCube = value; } } 

    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    void Update()
    {
        CubeSliding();
    }

    private void CubeSliding()
    {
        if (_baseCube != null && _isPointerDown)
        {
            _baseCube.transform.position = Vector3.Lerp(_baseCube.transform.position, _cubePosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void OnPointerDown()
    {
        _isPointerDown = true;
    }

    public void OnPointerDrag(float xMovement)
    {
        if (_baseCube != null && _isPointerDown)
        {
            _cubePosition = _baseCube.transform.position;
            _cubePosition.x = xMovement * _cubeMaxPositionX;
        }
    }

    public void OnPointerUp()
    {
        if (_baseCube != null)
        {
            if (_isPointerDown && _canMove)
            {
                _canMove = false;
                _isPointerDown = false;
            }
            _baseCube.CubeRigidBody.AddForce(-Vector3.forward * _pushForce, ForceMode.Impulse);
            OnClickUpEvent?.Invoke();
        }
    }
}