using UnityEngine;

public class MusicList : MonoBehaviour
{
    [Header("Music AudioClips")]

    [Header("Background sound")]
    [SerializeField] private AudioClip _backgroundMusic;

    public AudioClip BackgroundMusic => _backgroundMusic;
}