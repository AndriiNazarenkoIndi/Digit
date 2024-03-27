using UnityEngine;

public class AttacherDetacherCubeFX : MonoBehaviour
{
    [SerializeField] PlayVisualFX _playVisualFX;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Start()
    {
        AttachCubeEvents();
    }

    private void AttachCubeEvents()
    {
        _eventAttacherDetacher.AttachDetach(() => Cube.CollisionWithMatchingCubeReturn += _playVisualFX.PlayCubeExplosionFX);
    }

    private void DetachCubeEvents()
    {
        _eventAttacherDetacher.AttachDetach(() => Cube.CollisionWithMatchingCubeReturn -= _playVisualFX.PlayCubeExplosionFX);
    }

    private void OnDestroy()
    {
        DetachCubeEvents();
    }
}