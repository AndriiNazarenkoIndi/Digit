using UnityEngine;

public class RedBorder : MonoBehaviour
{
    public delegate void CubeCollisionRedBorder();
    public event CubeCollisionRedBorder CubeCollisionRedBorderEvent;

    private bool _borderTrigger = false;

    private void OnTriggerStay(Collider other)
    {
        if (!_borderTrigger && other.gameObject.TryGetComponent(out Cube cube) && cube.EntryUntoGame)
        {
            _borderTrigger = true;
            CubeCollisionRedBorderEvent?.Invoke();
        }
    }
}