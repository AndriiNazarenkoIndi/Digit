using System;
using UnityEngine;

public class SaveLoadSoundDataSystem : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;

    private SaveSystem _soundDataSaveSystem;
    private SoundDataToSave _soundDataToSave;

    private string _nameSoundSettingFile = "SoundInfo.dig";

    private void Awake()
    {
        InitSaveSystem();
        InitSaveData();
        LoadSoundSetting();
    }

    private void InitSaveSystem()
    {
        _soundDataSaveSystem = new SaveSystem(_nameSoundSettingFile);
    }

    private void InitSaveData()
    {
        _soundDataToSave = new SoundDataToSave();
    }

    public void SaveSoundSetting()
    {
        try
        {
            _soundDataToSave.musicStatus = _soundManager._musicStatus;
            _soundDataToSave.soundStatus = _soundManager._soundStatus;
            _soundDataSaveSystem.Save(_soundDataToSave);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }

    public void LoadSoundSetting()
    {
        try
        {
            _soundDataSaveSystem.Load(_soundDataToSave);
            _soundManager._musicStatus = _soundDataToSave.musicStatus;
            _soundManager._soundStatus = _soundDataToSave.soundStatus;
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }
}