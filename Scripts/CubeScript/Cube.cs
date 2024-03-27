using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody _cubeRigidbody;
    [SerializeField] private CubeTypeDefinition _cubeTypeDefinition;
    
    [SerializeField] [Range(1, 50)] private int _standartPoint = 15;
    [SerializeField] [Range(1, 500)] private int _maxPoint = 200;
    [SerializeField] [Range(1.0f, 10.0f)] private float _pushJumpForce = 1.0f;

    private bool _isMainCube;
    private bool _entryIntoGame = false;

    private int _personalCubeNumber;
    private int _thisCubeValue;
    private int _maxTypeValue;

    private static int _cubeID = 0;
    public static int pointCount;

    public delegate void CollisionEventHandler();
    public static event CollisionEventHandler CollisionWithMatchingCube;

    public delegate void CollisionEventHandlerCubeReturn(GameObject returendCube);
    public static event CollisionEventHandlerCubeReturn CollisionWithMatchingCubeReturn;

    public bool EntryUntoGame
    {
        get { return _entryIntoGame; }
        set { _entryIntoGame = value; }
    }
    public Rigidbody CubeRigidBody => _cubeRigidbody;
    public bool IsMainCube
    {
        get { return _isMainCube; }
        set { _isMainCube = value; }
    }

    private void Start()
    {
        SetCubePoint(0);
        PersonalCubeNumberInit();
        InitCubeTypeValue();
    }

    #region Base init
    private void PersonalCubeNumberInit()
    {
        _cubeID += 1;
        _personalCubeNumber = _cubeID;
    }

    private void InitCubeTypeValue()
    {
        _maxTypeValue = _cubeTypeDefinition.MaxValue;
        _thisCubeValue = _cubeTypeDefinition.CubeValueOut;
    }

    private void SetCubePoint(int point)
    {
        pointCount = point;
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null && collision.gameObject.TryGetComponent(out Cube cube))
        {
            _entryIntoGame = true;
            CompareCubeValue(cube);
        }
    }

    private void CompareCubeValue(Cube cube)
    {
        if (cube._thisCubeValue == _thisCubeValue)
        {
            if (_personalCubeNumber > cube._personalCubeNumber)
            {
                HandleCollision(cube, this);
            }
            else
            {
                HandleCollision(this, cube);
            }
        }
    }

    private void HandleCollision(Cube deleteCube, Cube upgradeCube)
    {
        CubeDestoy(deleteCube, (_thisCubeValue + _standartPoint));
        UpdateCube(upgradeCube);
        DestroyLastCube(upgradeCube._thisCubeValue, upgradeCube);
    }

    private void DestroyLastCube(int cubeValue, Cube cube)
    {
        if (cubeValue >= _maxTypeValue)
        {
            CubeDestoy(cube, _maxPoint);
        }
    }

    private void CubeDestoy(Cube cube, int point)
    {
        SetCubePoint(point);
        EventInvoke(cube);
        Destroy(cube.gameObject);
    }

    private void UpdateCube(Cube cube)
    {
        SetNewValueAndColor(ref cube._thisCubeValue, cube._cubeTypeDefinition);
        JumpUpdateCube(cube);
    }

    private void SetNewValueAndColor(ref int value, CubeTypeDefinition cubeType)
    {
        value += 1;
        if (cubeType != null && value < _maxTypeValue)
        {
            cubeType.SetCubeMaterial(value);
        }
    }

    private void JumpUpdateCube(Cube cube)
    {
        if (_cubeRigidbody != null)
        {
            cube._cubeRigidbody.AddForce(Vector3.up * _pushJumpForce, ForceMode.Impulse);
        }
    }

    private void EventInvoke(Cube cube)
    {
        CollisionWithMatchingCube?.Invoke();
        CollisionWithMatchingCubeReturn?.Invoke(cube.gameObject);
    }
}