using UnityEngine;

[CreateAssetMenu(fileName = "ScoreValueSetting", menuName = "Settings/ScoreValueSetting")]
public class ScoreValueSetting : ScriptableObject
{
    [SerializeField] [Range(0, 1000)] private int _standartPoint = 10;
    [SerializeField] [Range(0, 10000)] private int _diamondBonusPoint = 100;
    [SerializeField] [Range(0, 99999)] private int _maxDiamondValue = 9999;

    public int StandartPoint => _standartPoint;
    public int DiamondBonusPoint => _diamondBonusPoint;
    public int MaxDiamondValue => _maxDiamondValue;
}