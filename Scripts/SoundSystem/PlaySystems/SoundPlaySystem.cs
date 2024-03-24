using UnityEngine;

public class SoundPlaySystem
{
    private AudioSource _audioSource;

    public SoundPlaySystem(AudioSource _soundAudioSource)
    {
        _audioSource = _soundAudioSource;
    }

    #region Sound Effect Play

    public void ExsplosionSoundPlay(AudioClip exsplosionSound)
    {
        SoundPlayOneShot(exsplosionSound);
    }

    public void CubeClickSoundPlay(AudioClip cubeClickSound)
    {
        SoundPlayOneShot(cubeClickSound);
    }

    public void GameOverSoundPlay(AudioClip gameOverSound)
    {
        SoundPlayOneShot(gameOverSound);
    }

    public void ButtonClickSoundPlay(AudioClip buttonClickSound)
    {
        SoundPlayOneShot(buttonClickSound);
    }

    #endregion

    private void SoundPlayOneShot(AudioClip sound)
    {
        if (_audioSource != null)
        {
            _audioSource.PlayOneShot(sound);
        }
    }
}