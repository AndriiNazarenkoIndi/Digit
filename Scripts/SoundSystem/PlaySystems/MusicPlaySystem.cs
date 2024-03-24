using UnityEngine;

public class MusicPlaySystem
{
    private AudioSource _audioSource;

    public MusicPlaySystem(AudioSource musicAudioSource)
    {
        _audioSource = musicAudioSource;
    }

    public void PlayBackgroundMusic(AudioClip backgroundMusic)
    {
        if (_audioSource != null)
        {
            _audioSource.clip = backgroundMusic;
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}