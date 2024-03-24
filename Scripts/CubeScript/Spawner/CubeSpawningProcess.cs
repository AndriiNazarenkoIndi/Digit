using System.Collections;
using UnityEngine;

public class CubeSpawningProcess : MonoBehaviour
{
    [SerializeField] private CubeController _cubeController;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField][Range(0.0f, 5.0f)] private float _timeToSpawn = 1.0f;

    private Cube _baseCube;

    private void Start()
    {
        SpawnCube();
    }

    private void SpawnCube()
    {
        _baseCube = _cubeSpawner.CubeSpawn(_spawnPoint);
        _baseCube.IsMainCube = true;
        _cubeController.BaseCube = _baseCube;
        _cubeController.CanMove = true;
    }

    private void SpawnNewCube()
    {
        _baseCube.IsMainCube = false;
        SpawnCube();
    }

    public void CubeSpawnByTiming()
    {
        StartCoroutine(SpawnByTiming(_timeToSpawn));
    }

    private IEnumerator SpawnByTiming(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        SpawnNewCube();
    }
}