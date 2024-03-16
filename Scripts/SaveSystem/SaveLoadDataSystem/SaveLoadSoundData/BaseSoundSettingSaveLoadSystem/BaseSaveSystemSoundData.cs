using UnityEngine;

public abstract class BaseSaveSystemSoundData
{
    protected SoundManager _soundManager;
    protected SoundDataToSave _soundSetting;
    protected ISaveSystem _saveSystem;
    private string _fileName;

    public BaseSaveSystemSoundData(SoundManager soundManager)
    {
        _soundManager = soundManager;
        InitSaveSystem();
        InitSoundSetting();
    }

    protected virtual void InitSaveSystem()
    {
        _fileName = SaveSystemConfig.nameSoundDataFile;
        _saveSystem = new SaveSystem(_fileName);
    }

    protected virtual void InitSoundSetting()
    {
        _soundSetting = new SoundDataToSave();
    }
}