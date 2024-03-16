using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] [Range(10, 30)] private int _cubesQueueCapacity = 20;
    [SerializeField] private bool _autoQueueGrow = true;
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _spawnPoint;

    private Queue<Cube> _cubesQueue = new Queue<Cube>();
    private Cube _cubeInQueue;
    private Vector3 _defaultSpawnPosition;

    private void Awake()
    {
        SetDefaultPosition();
        InitializeCubesQueue();
    }

    private void SetDefaultPosition()
    {
        _defaultSpawnPosition = _spawnPoint.transform.position;
    }

    private void InitializeCubesQueue()
    {
        for (int i = 0; i < _cubesQueueCapacity; i++)
        {
            AddCubeToQueue();
        }
    }

    private void AddCubeToQueue()
    {
        _cubeInQueue = Instantiate(_cubePrefab, _defaultSpawnPosition, Quaternion.identity, transform).GetComponent<Cube>();
        _cubeInQueue.gameObject.SetActive(false);
        _cubeInQueue.IsMainCube = false;
        _cubesQueue.Enqueue(_cubeInQueue);
    }

    private Cube SpawnProcess(Vector3 position)
    {
        if (_cubesQueue.Count == 0)
        {
            if (_autoQueueGrow)
            {
                _cubesQueueCapacity++;
                AddCubeToQueue();
            }
            else
            {
                Debug.LogError("[Cubes Queue] : no more cubes available in the pool");
                return null;
            }
        }
        _cubeInQueue = _cubesQueue.Dequeue();
        _cubeInQueue.transform.position = position;
        _cubeInQueue.gameObject.SetActive(true);
        return _cubeInQueue;
    }

    public Cube CubeSpawn()
    {
        return SpawnProcess(_defaultSpawnPosition);
    }
}