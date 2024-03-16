using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] MultiplierCounter _multiplierCounter;

    private int _maxScore;
    private int _localScore;
    private int _maxScoreValue = 999999;

    public delegate void LocalScoreUpdate();
    public event LocalScoreUpdate LocalScoreUpdateEvent;

    public int LocalScore => _localScore;
    public int MaxScore
    {
        get { return _maxScore; }
        set { _maxScore = value; }
    }

    private void Start()
    {
        SubscribeEvent();
    }

    #region Subscribe/Unsubscribe Event

    private void SubscribeEvent()
    {
        Cube.CollisionWithMatchingCube += SetLocalScore;
    }

    private void UnsubscribeEvent()
    {
        Cube.CollisionWithMatchingCube -= SetLocalScore;
    }
    #endregion

    public void SetLocalScore()
    {
        _localScore += Cube.pointCount * _multiplierCounter.MultiplierValue;
        LocalScoreUpdateEvent?.Invoke();
    }

    public void SetNewMaxScore()
    {
        if (_localScore > _maxScore)
        {
            if (_maxScore >= _maxScoreValue)
            {
                ScoreZeroing();
            }
            else
            {
                _maxScore = _localScore;
            }
        }
    }

    private void ScoreZeroing()
    {
        _maxScore = 0;
    }

    private void OnDestroy()
    {
        UnsubscribeEvent();
    }
}