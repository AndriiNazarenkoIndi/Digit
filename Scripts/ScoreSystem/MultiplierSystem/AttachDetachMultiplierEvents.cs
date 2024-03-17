using UnityEngine;

public class AttachDetachMultiplierEvents : MonoBehaviour
{
    [Header("Base Setting")]
    [SerializeField] private MultiplierCounter _multiplierCounter;

    public delegate void MultiplierCounterUpdate();
    public MultiplierCounterUpdate MultiplierValueUpdateEvent;

    private void Start()
    {
        AttachToEvent();
    }

    private void AttachToEvent()
    {
        if (_multiplierCounter != null)
        {
            Cube.CollisionWithMatchingCube += _multiplierCounter.SetMultiplierValue;
            Cube.CollisionWithMatchingCube += _multiplierCounter.SetTimeMultiplierReset;
        }
    }

    private void DetachToEvent()
    {
        if(_multiplierCounter != null)
        {
            Cube.CollisionWithMatchingCube -= _multiplierCounter.SetTimeMultiplierReset;
            Cube.CollisionWithMatchingCube -= _multiplierCounter.SetMultiplierValue;
        }
    }

    private void OnDestroy()
    {
        DetachToEvent();
    }
}