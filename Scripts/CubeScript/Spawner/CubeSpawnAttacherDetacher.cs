using UnityEngine;

public class CubeSpawnAttacherDetacher : MonoBehaviour
{
    [SerializeField] private CubeSpawningProcess _cubeSpawningProcess;
    [SerializeField] private CubeController _cubeController;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Awake()
    {
        AttachSpawnEvent();
    }

    private void AttachSpawnEvent()
    {
        _eventAttacherDetacher.AttachDetach(_cubeController, () => _cubeController.OnClickUpEvent += _cubeSpawningProcess.CubeSpawnByTiming);
    }

    private void DetachSpawnEvent()
    {
        _eventAttacherDetacher.AttachDetach(_cubeController, () => _cubeController.OnClickUpEvent -= _cubeSpawningProcess.CubeSpawnByTiming);
    }

    private void OnDestroy()
    {
        DetachSpawnEvent();
    }
}