using UnityEngine;
using UnityEngine.UI;

public class UISetActiveManager : MonoBehaviour
{
    [Header("Game Over Panel")]
    [SerializeField] private UIPanel _gameOverPanel;
    private bool _setActiveGameOverPanel = false;

    [Header("Game Setting Panel")]
    [SerializeField] private UIPanel _gameSettingPanel;
    private bool _setActiveSettintgPanel = false;

    [Header("Control Slider")]
    [SerializeField] private Slider _controlSlider;
    private bool _setActiveSlider = true;

    private UIObjectSetActive _uiObjectSetActive = new UIObjectSetActive();

    public void SetActiveGameOverPanel()
    {
        _setActiveGameOverPanel = true;
        _setActiveSlider = !_setActiveSlider;
        _uiObjectSetActive.UIGameObjectSetActive(_gameOverPanel, _setActiveGameOverPanel);
        SetActiveSlider(_setActiveSlider);
    }

    public void SetActiveSettingPanel()
    {
        _setActiveSettintgPanel = !_setActiveSettintgPanel;
        _setActiveSlider = !_setActiveSlider;
        _uiObjectSetActive.UIGameObjectSetActive(_gameSettingPanel, _setActiveSettintgPanel);
        SetActiveSlider(_setActiveSlider);
    }

    private void SetActiveSlider(bool isActive)
    {
        _uiObjectSetActive.UIGameObjectSetActive(_controlSlider, isActive);
    }
}