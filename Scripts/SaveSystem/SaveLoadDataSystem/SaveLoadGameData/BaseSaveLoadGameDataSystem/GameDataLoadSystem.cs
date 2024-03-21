using System;
using UnityEngine;

public class GameDataLoadSystem : BaseSaveSystemGameData, ILoad
{
    private ScoreCounter _scoreCounter;

    public GameDataLoadSystem(ScoreCounter scoreCounter) : base() 
    { 
        _scoreCounter = scoreCounter;
    }

    public void Load()
    {
        try
        {
            _saveSystem.Load(_gameData);
            AssigningValues();
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }

    private void AssigningValues()
    {
        _scoreCounter.MaxScore = _gameData.maxScoreValue;
    }
}