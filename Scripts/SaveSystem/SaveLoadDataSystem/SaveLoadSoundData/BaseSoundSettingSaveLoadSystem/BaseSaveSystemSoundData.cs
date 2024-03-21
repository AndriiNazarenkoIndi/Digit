public abstract class BaseSaveSystemSoundData
{
    protected SoundDataToSave _soundSetting;
    protected ISaveSystem _saveSystem;
    private string _fileName;

    public BaseSaveSystemSoundData()
    {
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