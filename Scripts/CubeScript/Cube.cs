using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] [Range(1, 50)] private int _standartPoint = 5;
    [SerializeField] [Range(1, 500)] private int _maxPoint = 200;
    [SerializeField] [Range(1.0f, 10.0f)] private float _pushForce = 1.0f;
    [SerializeField] private ParticleSystem _explosionParticle;

    Rigidbody _cubeRigidbody;
    private CubeTypeDefinition _cubeTypeDefinition;

    private bool _isMainCube;
    private bool _entryIntoGame = false;

    private int _personalCubeNumber;
    private int _thisCubeValue;
    private int _maxTypeValue;

    private static int _cubeID;
    public static int pointCount;

    public delegate void CollisionEventHandler();
    public static event CollisionEventHandler CollisionWithMatchingCube;

    public bool EntryUntoGame => _entryIntoGame;
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
        GetComponentInit();
        InitCubeTypeValue();
    }

    #region Base init
    private void PersonalCubeNumberInit()
    {
        _cubeID += 1;
        _personalCubeNumber = _cubeID;
    }

    private void GetComponentInit()
    {
        _cubeRigidbody = GetComponent<Rigidbody>();
        _cubeTypeDefinition = GetComponent<CubeTypeDefinition>();
    }

    private void InitCubeTypeValue()
    {
        _maxTypeValue = _cubeTypeDefinition.MaxValue;
        _thisCubeValue = _cubeTypeDefinition.CubeValueOut;
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null && collision.gameObject.TryGetComponent(out Cube cube))
        {
            _entryIntoGame = true;
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
    }

    private void HandleCollision(Cube deleteCube, Cube upgradeCube)
    {
        SetCubePoint(_thisCubeValue + _standartPoint);
        Destroy(deleteCube.gameObject);
        SetNewValueAndColor(ref upgradeCube._thisCubeValue, upgradeCube._cubeTypeDefinition);
        CubeExposionEffect(upgradeCube);
        DestroyLastCube(upgradeCube._thisCubeValue, upgradeCube.gameObject);
        CollisionWithMatchingCube?.Invoke();
    }

    private void SetCubePoint(int point)
    {
        pointCount = point;
    }

    private void SetNewValueAndColor(ref int value, CubeTypeDefinition cubeType)
    {
        value += 1;
        if (value < _maxTypeValue)
        {
            cubeType.SetCubeMaterial(value);
            cubeType.SetCubeValueText(value);
        }
    }

    private void DestroyLastCube(int cubeValue, GameObject cube)
    {
        if (cubeValue >= _maxTypeValue)
        {
            SetCubePoint(_maxPoint);
            Destroy(cube);
        }
    }

    private void CubeExposionEffect(Cube cube)
    {
        cube._cubeRigidbody.AddForce(Vector3.up * _pushForce, ForceMode.Impulse);
        cube._explosionParticle.Play();
    }
}