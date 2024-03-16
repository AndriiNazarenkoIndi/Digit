using UnityEngine;
using UnityEngine.Events;

public class CubeController : MonoBehaviour
{
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private Cube _baseCube;
    [SerializeField] private SliderControl _sliderControl;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _cubeMaxPositionX;
    [SerializeField][Range(0.1f, 2.0f)] private float _timeToSpawn = 0.5f;

    public UnityEvent OnClickUp;

    private Vector3 _cubePosition;
    private bool _isPointerDown;
    private bool _canMove;

    void Start()
    {
        SpawnCube();
        SubscribeOnPointerEvent();
    }

    #region Subscribe/Unsubscribe OnPointerEvent
    private void SubscribeOnPointerEvent()
    {
        _sliderControl._OnPointerDownEvent += OnPointerDown;
        _sliderControl._OnPointerDragEvent += OnPointerDrag;
        _sliderControl._OnPointerUpEvent += OnPointerUp;
    }

    private void UnsubscribeOnPointerEvent()
    {
        _sliderControl._OnPointerUpEvent -= OnPointerUp;
        _sliderControl._OnPointerDragEvent -= OnPointerDrag;
        _sliderControl._OnPointerDownEvent -= OnPointerDown;
    }
    #endregion

    void Update()
    {
        if (_baseCube != null && _isPointerDown)
        {
            _baseCube.transform.position = Vector3.Lerp(_baseCube.transform.position, 
                                                         _cubePosition,
                                                         _moveSpeed * Time.deltaTime);
        }
    }

    private void OnPointerDown()
    {
        _isPointerDown = true;
    }

    private void OnPointerDrag(float xMovement)
    {
        if (_baseCube != null && _isPointerDown)
        {
            _cubePosition = _baseCube.transform.position;
            _cubePosition.x = xMovement * _cubeMaxPositionX;
        }
    }

    private void OnPointerUp()
    {
        if (_baseCube != null)
        {
            if (_isPointerDown && _canMove)
            {
                _canMove = false;
                _isPointerDown = false;
            }
            _baseCube.CubeRigidBody.AddForce(-Vector3.forward * _pushForce, ForceMode.Impulse);
            OnClickUp?.Invoke();
            Invoke("SpawnNewCube", _timeToSpawn);
        }
    }

    private void OnDestroy()
    {
        UnsubscribeOnPointerEvent();
    }

    private void SpawnCube()
    {
        _canMove = true;
        _baseCube = _blockSpawner.CubeSpawn();
        _baseCube.IsMainCube = true;
        _cubePosition = _baseCube.transform.position;
    }

    private void SpawnNewCube()
    {
        _baseCube.IsMainCube = false;
        SpawnCube();
    }
}