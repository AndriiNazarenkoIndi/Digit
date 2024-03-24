using UnityEngine;

public class GameOverAttachDetach : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private RedBorder _redBorder;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        AttachGameOverEvent();
    }

    private void AttachGameOverEvent()
    {
        _eventAttacherDetacher.AttachDetach(_redBorder, () => _redBorder.CubeCollisionRedBorderEvent += _gameManager.GameStop);
    }

    private void DetachGameOverEvent()
    {
        _eventAttacherDetacher.AttachDetach(_redBorder, () => _redBorder.CubeCollisionRedBorderEvent -= _gameManager.GameStop);
    }

    private void OnDestroy()
    {
        DetachGameOverEvent();
    }
}