using UnityEngine;

public class SoundPlayAttacherDetacher : MonoBehaviour
{
    [SerializeField] private SoundPlayManager _soundPlayManager;

    [Header("Subscription sources")]
    [SerializeField] private CubeController _cubeController;
    [SerializeField] private GameManager _gameManager;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        AttachBaseEvents();
    }

    private void AttachBaseEvents()
    {
        _eventAttacherDetacher.AttachDetach(() => Cube.CollisionWithMatchingCube += _soundPlayManager.ExsplosionSoundPlay);
        _eventAttacherDetacher.AttachDetach(_cubeController, () => _cubeController.OnClickUpEvent += _soundPlayManager.CubeClickSoundPlay);
        _eventAttacherDetacher.AttachDetach(_gameManager, () => _gameManager.GameOverStatusEvent += _soundPlayManager.GameOverSoundPlay);
    }

    private void DetachBaseEvents()
    {
        _eventAttacherDetacher.AttachDetach(_gameManager, () => _gameManager.GameOverStatusEvent -= _soundPlayManager.GameOverSoundPlay);
        _eventAttacherDetacher.AttachDetach(_cubeController, () => _cubeController.OnClickUpEvent -= _soundPlayManager.CubeClickSoundPlay);
        _eventAttacherDetacher.AttachDetach(() => Cube.CollisionWithMatchingCube -= _soundPlayManager.ExsplosionSoundPlay);
    }

    private void OnDestroy()
    {
        DetachBaseEvents();
    }
}