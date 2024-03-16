using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound effects")]
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioClip _cubeClickSound;
    [SerializeField] private AudioClip _buttonClickSound;
    [SerializeField] private AudioClip _gameOverSound;

    [Header("Audio sources")]
    [SerializeField] private AudioSource _soundAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;

    [Header("Volume value")]
    [SerializeField] [Range(0.0f, 1.0f)] private float _maxSoundVolume = 0.7f;
    [SerializeField] [Range(0.0f, 1.0f)] private float _maxMusicVolume = 0.3f;

    public bool _musicStatus = true;
    public bool _soundStatus = true;

    private void Start()
    {
        InitSoundManager();
    }

    private void InitSoundManager()
    {
        SetAudioVulume();
        OnOffMusicPlay();
        OnOffSoundEffectPlay();
        SubscribeCubeCollisionEvent();
        PlayBackgroundMusic();
    }

    #region Subscribe/Unsubscribe event cube collision
    private void SubscribeCubeCollisionEvent()
    {
        Cube.CollisionWithMatchingCube += HandleMatchingCubeCollision;
    }

    private void UnsubscribeCubeCollisionEvent()
    {
        Cube.CollisionWithMatchingCube -= HandleMatchingCubeCollision;
    }
    #endregion

    private void SetAudioVulume()
    {
        _musicAudioSource.volume = _maxMusicVolume;
        _soundAudioSource.volume = _maxSoundVolume;
    }

    private void HandleMatchingCubeCollision()
    {
        _soundAudioSource.PlayOneShot(_explosionSound);
    }

    private void OnDestroy()
    {
        UnsubscribeCubeCollisionEvent();
    }

    #region Sound effect functions 
    public void ButtonOnClickSoundPlay()
    {
        _soundAudioSource.PlayOneShot(_buttonClickSound);
    }

    public void CubeClickSoundPlay()
    {
        _soundAudioSource.PlayOneShot(_cubeClickSound);
    }

    public void GameOverSoundPlay()
    {
        _soundAudioSource.PlayOneShot(_gameOverSound);
    }

    private void PlayBackgroundMusic()
    {
        if (_musicAudioSource != null)
        {
            _musicAudioSource.Play();
        }
    }
    #endregion

    #region Sound Setting
    public void OnOffMusicPlay()
    {
        _musicAudioSource.mute = _musicStatus;
    }

    public void OnOffSoundEffectPlay()
    {
        _soundAudioSource.mute = _soundStatus;
    }

    public void MusicStatusInverse()
    {
        _musicStatus = !_musicStatus;
    }

    public void SoundStatusInverse()
    {
        _soundStatus = !_soundStatus;
    }
    #endregion
}