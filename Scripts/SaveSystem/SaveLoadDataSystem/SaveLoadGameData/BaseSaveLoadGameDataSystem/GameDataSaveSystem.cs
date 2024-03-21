using System;
using UnityEngine;

public class GameDataSaveSystem : BaseSaveSystemGameData, ISave
{
    private ScoreCounter _scoreCounter;

    public GameDataSaveSystem(ScoreCounter scoreCounter) : base() 
    { 
        _scoreCounter = scoreCounter;
    }

    public void Save()
    {
        try
        {
            AssigningValues();
            _saveSystem.Save(_gameData);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }

    private void AssigningValues()
    {
        _gameData.maxScoreValue = _scoreCounter.MaxScore;
    }
}