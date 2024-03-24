using UnityEngine;

public class SoundList : MonoBehaviour
{
    [Header("Sound AudioClips")]

    [Header("Game process sound effets")]
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _cubeClickSound;

    [Header("Win/GameOver sound")]
    [SerializeField] private AudioClip _gameOverSound;

    [Header("UI event effect sound")]
    [SerializeField] private AudioClip _buttonClickSound;

    public AudioClip ExplosionSound => _explosionSound;
    public AudioClip CubeClickSound => _cubeClickSound;
    public AudioClip GameOverSound => _gameOverSound;
    public AudioClip ButtonClickSound => _buttonClickSound;
}