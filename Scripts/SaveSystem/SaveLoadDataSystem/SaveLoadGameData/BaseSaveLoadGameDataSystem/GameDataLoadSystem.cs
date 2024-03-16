using System;
using UnityEngine;

public class GameDataLoadSystem : BaseSaveSystemGameData, ILoad
{
    public GameDataLoadSystem(ScoreCounter scoreCounter) : base(scoreCounter) { }

    public void Load()
    {
        try
        {
            _saveSystem.Load(_gameData);
            _scoreCounter.MaxScore = _gameData.maxScoreValue;
        }
        catch (Exception ex)
        {
            Debug.Log("Load is failed. Exception: " + ex);
        }
    }
}