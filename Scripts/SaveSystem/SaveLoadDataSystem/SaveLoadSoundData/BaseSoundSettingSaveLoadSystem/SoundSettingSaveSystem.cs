using System;
using UnityEngine;

public class SoundSettingSaveSystem : BaseSaveSystemSoundData, ISave
{
    private AudioManager _audioManager;

    public SoundSettingSaveSystem(AudioManager audioManager) : base() 
    {
        _audioManager = audioManager;
    }

    public void Save()
    {
        try
        {
            AssigningValues();
            _saveSystem.Save(_soundSetting);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }

    private void AssigningValues()
    {
        _soundSetting.musicStatus = _audioManager.MusicStatus;
        _soundSetting.soundStatus = _audioManager.SoundStatus;
    }
}