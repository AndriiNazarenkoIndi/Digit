using UnityEngine;

public class MultiplierCounter : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 5.0f)] private float _timeToReset = 1.2f;

    public delegate void MultiplierCounterUpdate();
    public MultiplierCounterUpdate MultiplierValueUpdateEvent;

    private int _multiplierValue = 1;
    private Timer _multiplierUpdateTimer;

    public int MultiplierValue => _multiplierValue;

    private void Start()
    {
        InitTimer();
    }

    private void InitTimer()
    {
        _multiplierUpdateTimer = new Timer(_timeToReset);
    }

    public void SetMultiplierValue()
    {
        if (_multiplierUpdateTimer.CountdowmInSec())
        {
            _multiplierValue = 1;
            MultiplierValueUpdateEvent?.Invoke();
        }
        else
        {
            _multiplierValue++;
            MultiplierValueUpdateEvent?.Invoke();
        }
    }

    public void SetTimeMultiplierReset()
    {
        _multiplierUpdateTimer.SetTime();
    }
}