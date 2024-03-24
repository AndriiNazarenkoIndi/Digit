using UnityEngine;

public class AudioVolumeSetting
{
    private AudioSource _audioSource;

    public AudioVolumeSetting(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }

    public void SetVolumeValue(float volumeValue)
    {
        if (_audioSource != null)
        {
            _audioSource.volume = volumeValue;
        }
    }
}