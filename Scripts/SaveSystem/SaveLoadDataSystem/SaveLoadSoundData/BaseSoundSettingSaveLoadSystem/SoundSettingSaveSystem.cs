using System;
using UnityEngine;

public class SoundSettingSaveSystem : BaseSaveSystemSoundData, ISave
{
    private SoundManager _soundManager;

    public SoundSettingSaveSystem(SoundManager soundManager) : base() 
    {
        _soundManager = soundManager;
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
        _soundSetting.musicStatus = _soundManager._musicStatus;
        _soundSetting.soundStatus = _soundManager._soundStatus;
    }
}