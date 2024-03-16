using System;
using UnityEngine;

public class SoundSettingLoadSystem : BaseSaveSystemSoundData, ILoad
{
    public SoundSettingLoadSystem(SoundManager soundManager) : base(soundManager) { }

    public void Load()
    {
        try
        {
            _saveSystem.Load(_soundSetting);
            _soundManager._musicStatus = _soundSetting.musicStatus;
            _soundManager._soundStatus = _soundSetting.soundStatus;
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }
}