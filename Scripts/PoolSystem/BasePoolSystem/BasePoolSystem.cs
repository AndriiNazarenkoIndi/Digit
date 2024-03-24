using System.Collections.Generic;
using UnityEngine;

public class BasePoolSystem<T>: IPoolSystem<T> where T : MonoBehaviour
{
    private Queue<T> _poolObjects = new Queue<T>();
    private int _fillingThePoolElements = 0;
    private T _spawnObject;
    private T _poolObjectInQueue;

    public int FillingThePoolElements => _fillingThePoolElements;

    public void FillingPool(int numberOfPoolElements, T poolObject, Transform poolPosition)
    {
        for (int i = 0; i < numberOfPoolElements; i++)
        {
            CreateAnObjectInPool(poolObject, poolPosition);
        }
    }

    public void CreateAnObjectInPool(T poolObject, Transform poolPosition)
    {
        _spawnObject = Object.Instantiate(poolObject, poolPosition).GetComponent<T>();
        _spawnObject.gameObject.SetActive(false);
        _poolObjects.Enqueue(_spawnObject);
        _fillingThePoolElements++;
    }

    public T SpawningAnObjectFromThePool(Transform spawnPosition)
    {
        _poolObjectInQueue = _poolObjects.Dequeue();
        _poolObjectInQueue.transform.position = spawnPosition.position;
        _poolObjectInQueue.gameObject.SetActive(true);
        _fillingThePoolElements--;
        return _poolObjectInQueue;
    }

    public void ReturningAnObjectToThePool(Transform poolPosition, T poolObject)
    {
        poolObject.gameObject.SetActive(false);
        poolObject.transform.position = poolPosition.position;
        _poolObjects.Enqueue(poolObject);
        _fillingThePoolElements++;
    }

    public void IncreasingCapacityPool(int numberOfPoolElements, T poolObject, Transform poolPosition)
    {
        FillingPool(numberOfPoolElements, poolObject, poolPosition);
    }
}