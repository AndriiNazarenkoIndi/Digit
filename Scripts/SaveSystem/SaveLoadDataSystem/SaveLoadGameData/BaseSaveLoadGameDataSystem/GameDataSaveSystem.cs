using System;
using UnityEngine;

public class GameDataSaveSystem : BaseSaveSystemGameData, ISave
{
    public GameDataSaveSystem(ScoreCounter scoreCounter) : base(scoreCounter) { }

    public void Save()
    {
        try
        {
            _gameData.maxScoreValue = _scoreCounter.MaxScore;
            _saveSystem.Save(_gameData);
        }
        catch (Exception ex)
        {
            Debug.Log("Save is failed. Exception: " + ex);
        }
    }
}