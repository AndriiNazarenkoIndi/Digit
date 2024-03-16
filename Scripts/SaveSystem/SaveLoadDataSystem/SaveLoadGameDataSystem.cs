using System;
using UnityEngine;

public class SaveLoadGameDataSystem : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private SaveSystem _gameDataSaveSystem;
    private GameDataToSave _gameDataToSave;

    private string _nameGameDataFile = "GameDataInfo.dig";

    private void Awake()
    {
        InitSaveSystem();
        InitSaveData();
        LoadGameData();
    }

    private void InitSaveSystem()
    {
        _gameDataSaveSystem = new SaveSystem(_nameGameDataFile);
    }

    private void InitSaveData()
    {
        _gameDataToSave = new GameDataToSave();
    }

    public void SaveGameData()
    {
        try
        {
            _gameDataToSave.maxScoreValue = _scoreCounter.MaxScore;
            _gameDataSaveSystem.Save(_gameDataToSave);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }

    public void LoadGameData()
    {
        try
        {
            _gameDataSaveSystem.Load(_gameDataToSave);
            _scoreCounter.MaxScore = _gameDataToSave.maxScoreValue;
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }
}