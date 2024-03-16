using System;
using UnityEngine;

public class SoundSettingSaveSystem : BaseSaveSystemSoundData, ISave
{
    public SoundSettingSaveSystem(SoundManager soundManager) : base(soundManager) { }

    public void Save()
    {
        try
        {
            _soundSetting.musicStatus = _soundManager._musicStatus;
            _soundSetting.soundStatus = _soundManager._soundStatus;
            _saveSystem.Save(_soundSetting);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }
}