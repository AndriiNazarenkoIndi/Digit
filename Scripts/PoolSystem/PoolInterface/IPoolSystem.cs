using UnityEngine;

public interface IPoolSystem<T>
{
    public int FillingThePoolElements { get; }
    public void FillingPool(int numberOfPoolElements, T poolObject, Transform poolPosition);
    public void CreateAnObjectInPool(T poolObject, Transform poolPosition);
    public T SpawningAnObjectFromThePool(Transform spawnPosition);
    public void ReturningAnObjectToThePool(Transform poolPosition, T poolObject);
    public void IncreasingCapacityPool(int numberOfPoolElements, T poolObject, Transform poolPosition);
}
