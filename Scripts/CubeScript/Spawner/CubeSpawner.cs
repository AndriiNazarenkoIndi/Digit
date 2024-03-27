using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int _cubesQueueCapacity = 60;
    [SerializeField] [Range(0, 30)] private int _increasingCapacityPool = 10;
    [SerializeField] private bool _autoQueueGrow = true;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _poolPosition;

    private IPoolSystem<Cube> _cubePoolSystem = new BasePoolSystem<Cube>();

    private void Awake()
    {
        AwakePoolInit();
    }

    private void AwakePoolInit()
    {
        _cubePoolSystem.FillingPool(_cubesQueueCapacity, _cubePrefab, _poolPosition);
    }

    private Cube SpawnProcess(Transform spawnPosition) 
    {
        if (_cubePoolSystem.FillingThePoolElements == 0)
        {
            if (_autoQueueGrow)
            {
                _cubePoolSystem.IncreasingCapacityPool(_increasingCapacityPool, _cubePrefab, _poolPosition);
            }
            else
            {
                Debug.LogError("[Cubes Queue] : no more cubes available in the pool");
                return null;
            }
        }
        return _cubePoolSystem.SpawningAnObjectFromThePool(spawnPosition);
    }

    public Cube CubeSpawn(Transform spawnPosition)
    {
        return SpawnProcess(spawnPosition);
    }

    public void ReturnCubeToPool(Cube returnedCube)
    {
        _cubePoolSystem.ReturningAnObjectToThePool(_poolPosition, returnedCube);
    }
}