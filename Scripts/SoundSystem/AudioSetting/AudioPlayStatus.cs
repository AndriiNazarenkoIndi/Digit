using UnityEngine;

public class AudioPlayStatus
{
    private AudioSource _audioSource;

    public AudioPlayStatus(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }

    public void SetMuteStatus(bool _muteStatus)
    {
        _audioSource.mute = _muteStatus;
    }

    public bool MuteStatusInverse(bool muteStatus)
    {
        return !muteStatus;
    }
}