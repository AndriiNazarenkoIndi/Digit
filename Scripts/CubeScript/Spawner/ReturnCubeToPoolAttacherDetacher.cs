using UnityEngine;

public class ReturnCubeToPoolAttacherDetacher : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        //AttachReturnToPool();
    }

    private void AttachReturnToPool()
    {
        //_eventAttacherDetacher.AttachDetach(() => Cube.CollisionWithMatchingCubeReturn += _cubeSpawner.ReturnCubeToPool);
    }

    private void DetachReturnToPool()
    {
        //_eventAttacherDetacher.AttachDetach(() => Cube.CollisionWithMatchingCubeReturn -= _cubeSpawner.ReturnCubeToPool);
    }

    private void OnDestroy()
    {
        //DetachReturnToPool();
    }
}