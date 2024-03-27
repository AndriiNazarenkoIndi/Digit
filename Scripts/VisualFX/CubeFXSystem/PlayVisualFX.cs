using UnityEngine;

public class PlayVisualFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void PlayCubeExplosionFX(GameObject objectPosition)
    {
        _particleSystem.transform.position = objectPosition.transform.position;
        _particleSystem.Play();
    }
}