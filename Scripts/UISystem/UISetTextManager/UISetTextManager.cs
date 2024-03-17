using TMPro;
using UnityEngine;

public class UISetTextManager : MonoBehaviour
{
    [Header("UI Score")]
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private MultiplierCounter _multiplierCounter;
    [SerializeField] private TMP_Text _localScoreText;
    [SerializeField] private TMP_Text _maxScoreText;
    [SerializeField] private TMP_Text _multiplierValueText;
    public ScoreCounter GetScoreCounter => _scoreCounter;
    public MultiplierCounter GetMultiplierCounter => _multiplierCounter;

    private TextSetter _textSetter = new TextSetter();

    private void Start()
    {
        BaseSetting();
    }

    private void BaseSetting()
    {
        SetMaxScoreText();
    }

    public void SetLocalScoreText()
    {
        _textSetter.IntValueSetText(_scoreCounter, _localScoreText, _scoreCounter.LocalScore);
    }

    public void SetMaxScoreText()
    {
        _textSetter.IntValueSetText(_scoreCounter, _maxScoreText, _scoreCounter.MaxScore);
    }

    public void SetMultiplierValueText()
    {
        _textSetter.IntValueSetText(_multiplierCounter, _multiplierValueText, _multiplierCounter.MultiplierValue);
    }
}