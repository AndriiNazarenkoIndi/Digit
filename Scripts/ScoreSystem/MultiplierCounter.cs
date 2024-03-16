using UnityEngine;

public class MultiplierCounter : MonoBehaviour
{
    [SerializeField] private float _timeToReset = 2.0f;
    private float _timeToMultiplierReset;
    private int _multiplierValue;

    public int MultiplierValue => _multiplierValue;
    public MultiplierCounter()
    {
        _multiplierValue = 1;
    }

    private void Start()
    {
        SubscribeToEvent();
    }

    #region Subscribe/Unscribe Event
    private void SubscribeToEvent()
    {
        Cube.CollisionWithMatchingCube += SetMultiplierValue;
        Cube.CollisionWithMatchingCube += SetTimeMultiplierReset;
    }

    private void UnsubscribeToEvent()
    {
        Cube.CollisionWithMatchingCube -= SetTimeMultiplierReset;
        Cube.CollisionWithMatchingCube -= SetMultiplierValue;
    }
    #endregion

    private void SetMultiplierValue()
    {
        if (_timeToMultiplierReset > Time.time)
        {
            _multiplierValue++;
        }
        else
        {
            _multiplierValue = 1;
        }
    }

    private void SetTimeMultiplierReset()
    {
        _timeToMultiplierReset = Time.time + _timeToReset;
    }

    private void OnDestroy()
    {
        UnsubscribeToEvent();
    }
}