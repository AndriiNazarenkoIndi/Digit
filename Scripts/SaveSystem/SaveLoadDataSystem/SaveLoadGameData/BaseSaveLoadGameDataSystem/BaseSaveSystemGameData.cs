public abstract class BaseSaveSystemGameData
{
    protected GameDataToSave _gameData;
    protected ISaveSystem _saveSystem;
    private string _fileName;

    protected BaseSaveSystemGameData()
    {
        InitSaveSystem();
        InitGameData();
    }

    protected virtual void InitSaveSystem()
    {
        _fileName = SaveSystemConfig.nameGameDataFile;
        _saveSystem = new SaveSystem(_fileName);
    }

    protected virtual void InitGameData()
    {
        _gameData = new GameDataToSave();
    }
}