using UnityEngine;
using UnityEngine.UI;

public class UISetActiveEventManager : MonoBehaviour
{
    [Header("Base setting")]
    [SerializeField] private UISetActiveManager _uiSetActiveManager;
    [SerializeField] private GameManager _gameManager;

    [Header("Event sources")]
    [SerializeField] private RedBorder _redBorder;
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _backToGameButton;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher(); 
    private UIButtonAddRemoveListener _iuButtonAddRemoveListener = new UIButtonAddRemoveListener();

    private void Start()
    {
        AttachToStandartLavel();
    }

    private void AttachToStandartLavel()
    {
        if (_gameManager != null && !_gameManager.IsMainMenu)
        {
            AttachSetActiveGameOverPanel();
            AttachSetActiveSettingPanel();
        }
    }

    private void DetachToStandartLavel()
    {
        if (_gameManager != null && !_gameManager.IsMainMenu)
        {
            DetachSetActiveGameOverPanel();
            DetachSetActiveSettingPanel();
        }
    }

    private void AttachSetActiveGameOverPanel()
    {
        _eventAttacherDetacher.AttachDetach(_redBorder, () => _redBorder.CubeCollisionRedBorderEvent += _uiSetActiveManager.SetActiveGameOverPanel);
    }

    private void DetachSetActiveGameOverPanel()
    {
        _eventAttacherDetacher.AttachDetach(_redBorder, () => _redBorder.CubeCollisionRedBorderEvent -= _uiSetActiveManager.SetActiveGameOverPanel);
    }

    private void AttachSetActiveSettingPanel()
    {
        _iuButtonAddRemoveListener.ButtonAddListener(_settingButton, _uiSetActiveManager.SetActiveSettingPanel);
        _iuButtonAddRemoveListener.ButtonAddListener(_backToGameButton, _uiSetActiveManager.SetActiveSettingPanel);
    }

    private void DetachSetActiveSettingPanel()
    {
        _iuButtonAddRemoveListener.ButtonRemoveListener(_backToGameButton, _uiSetActiveManager.SetActiveSettingPanel);
        _iuButtonAddRemoveListener.ButtonRemoveListener(_settingButton, _uiSetActiveManager.SetActiveSettingPanel);
    }

    private void OnDestroy()
    {
        DetachToStandartLavel();
    }
}