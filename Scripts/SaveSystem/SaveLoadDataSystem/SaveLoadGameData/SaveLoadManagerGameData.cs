using UnityEngine;

public class SaveLoadManagerGameData : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private ISave _gameDataSaveSystem;
    private ILoad _gameDataLoadSystem;

    private void Awake()
    {
        AwakeInitSaveLoadSystem(_scoreCounter);
        LoadGameData();
    }

    private void AwakeInitSaveLoadSystem(ScoreCounter scoreCounter)
    {
        if (scoreCounter != null)
        {
            _gameDataSaveSystem = new GameDataSaveSystem(scoreCounter);
            _gameDataLoadSystem = new GameDataLoadSystem(scoreCounter);
        }
    }

    public void LoadGameData()
    {
        if (_gameDataLoadSystem != null)
        {
            _gameDataLoadSystem.Load();
        }
        else
        {
            Debug.Log("GameDataLoadSystem is Null. Load is Failed.");
        }
    }

    public void SaveGameData()
    {
        if (_gameDataSaveSystem != null)
        {
            _gameDataSaveSystem.Save();
        }
        else
        {
            Debug.Log("GameDataSaveSystem is Null. Save is Failed.");
        }
    }
}