using System;
using UnityEngine;

public class SoundSettingLoadSystem : BaseSaveSystemSoundData, ILoad
{
    private SoundManager _soundManager;

    public SoundSettingLoadSystem(SoundManager soundManager) : base() 
    {
        _soundManager = soundManager;
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
        _soundManager._musicStatus = _soundSetting.musicStatus;
        _soundManager._soundStatus = _soundSetting.soundStatus;
    }
}