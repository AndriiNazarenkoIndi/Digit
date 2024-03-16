using UnityEngine;
using UnityEngine.Events;

public class RedBorder : MonoBehaviour
{
    public UnityEvent CollisionRedBorderEvent;
    private bool _borderTrigger = false;

    private void OnTriggerStay(Collider other)
    {
        if (!_borderTrigger && other.gameObject.TryGetComponent(out Cube cube) && cube.EntryUntoGame)
        {
            _borderTrigger = true;
            CollisionRedBorderEvent?.Invoke();
        }
    }
}