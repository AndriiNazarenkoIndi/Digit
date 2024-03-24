using System;
using UnityEngine;

public class SoundSettingLoadSystem : BaseSaveSystemSoundData, ILoad
{
    private AudioManager _audioManager;

    public SoundSettingLoadSystem(AudioManager audioManager) : base() 
    {
        _audioManager = audioManager;
    }

    public void Load()
    {
        try
        {
            _saveSystem.Load(_soundSetting);
            AssigningValues();
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }

    private void AssigningValues()
    {
        _audioManager.MusicStatus = _soundSetting.musicStatus;
        _audioManager.SoundStatus = _soundSetting.soundStatus;
    }
}