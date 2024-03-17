using UnityEngine;

public class UISetTextEventManager : MonoBehaviour
{
    [Header("Base setting")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UISetTextManager _uiSetTextManager;

    private ScoreCounter _scoreCounter;
    private MultiplierCounter _multiplierCounter;
    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        AttachToEventStandertLevel();
    }

    private void GettingAllSources()
    {
        _scoreCounter = _uiSetTextManager.GetScoreCounter;
        _multiplierCounter = _uiSetTextManager.GetMultiplierCounter;
    }

    private void AttachToEventStandertLevel()
    {
        if (_gameManager != null && !_gameManager.IsMainMenu)
        {
            GettingAllSources();
            AttachLocalScoreUpdateEvent();
            AttachMultiplierValueUpdateEvent();
        }
    }

    private void DetachToEventStandertLevel()
    {
        if (_gameManager != null && !_gameManager.IsMainMenu)
        {
            DetachLocalScoreUpdateEvent();
            DetachMultiplierValueUpdateEvent();
        }
    }

    private void AttachLocalScoreUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_scoreCounter, () => _scoreCounter.LocalScoreUpdateEvent += _uiSetTextManager.SetLocalScoreText);
    }

    private void DetachLocalScoreUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_scoreCounter, () => _scoreCounter.LocalScoreUpdateEvent -= _uiSetTextManager.SetLocalScoreText);
    }

    private void AttachMultiplierValueUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_multiplierCounter, () => _multiplierCounter.MultiplierValueUpdateEvent += _uiSetTextManager.SetMultiplierValueText);
    }

    private void DetachMultiplierValueUpdateEvent()
    {
        _eventAttacherDetacher.AttachDetach(_multiplierCounter, () => _multiplierCounter.MultiplierValueUpdateEvent -= _uiSetTextManager.SetMultiplierValueText);
    }

    private void OnDestroy()
    {
        DetachToEventStandertLevel();
    }
}