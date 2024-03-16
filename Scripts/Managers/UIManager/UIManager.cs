using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Score UI")]
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _localScoreText;
    [SerializeField] private TMP_Text _maxScoreText;

    [Header("Multiplier UI")]
    [SerializeField] private MultiplierCounter _multiplierCounter;
    [SerializeField] private TMP_Text _multiplierValueText;

    [Header("Game process UI")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIPanel _gameOverPanel;
    [SerializeField] private Slider _slider;

    [Header("Setting UI")]
    [SerializeField] private UIPanel _settingPanel;

    private void Start()
    {
        SubscribeEvent();
        MaxScoreUpdate();
    }

    #region Subscribe/Unsubscribe Event
    private void SubscribeEvent()
    {
        _gameManager.GameOverStatusEvent += GameOver;
        _scoreCounter.LocalScoreUpdateEvent += LocalScoreUpdate;
        _scoreCounter.LocalScoreUpdateEvent += MultiplierValueUpdate;
    }

    private void UnsubscribeEvent()
    {
        _scoreCounter.LocalScoreUpdateEvent -= MultiplierValueUpdate;
        _scoreCounter.LocalScoreUpdateEvent -= LocalScoreUpdate;
        _gameManager.GameOverStatusEvent -= GameOver;
    }
    #endregion

    private void GameOver()
    {
        UnsubscribeEvent();
        _slider.gameObject.SetActive(false);
        _gameOverPanel.gameObject.SetActive(true);
    }

    private void MaxScoreUpdate()
    {
        _maxScoreText.text = _scoreCounter.MaxScore.ToString();
    }

    private void LocalScoreUpdate()
    {
        _localScoreText.text = _scoreCounter.LocalScore.ToString();
    }

    private void MultiplierValueUpdate()
    {
        _multiplierValueText.text = _multiplierCounter.MultiplierValue.ToString();
    }

    private void OnDestroy()
    {
        UnsubscribeEvent();
    }
}