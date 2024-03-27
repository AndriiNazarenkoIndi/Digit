using UnityEngine;
using TMPro;

public class CubeTypeDefinition : MonoBehaviour
{
    [Header("If setting TMP_Text")]
    [SerializeField] private bool _setText = true;
    [SerializeField] private TMP_Text[] _text;

    [Header("Type materials")]
    [SerializeField] private Material[] _typeMaterials;

    private Renderer _baseMaterial;
    private int[] _cubeValues = new int[12] {2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096};
    private int _randomDigitForSetCubeValue;
    private int _maxValue;
    private int _cubeValueOut;

    public int MaxValue => _maxValue;
    public int CubeValueOut => _cubeValueOut;

    private void Awake()
    {
        GetBaseMaterial();
        SetCubeValue();
        SetCubeMaterial(_randomDigitForSetCubeValue);

        if (_setText)
        {
            SetCubeValueText(_randomDigitForSetCubeValue);
        }
    }
    
    private void GetBaseMaterial()
    {
        _baseMaterial = GetComponent<Renderer>();
    }

    private void SetCubeValue()
    {
        _randomDigitForSetCubeValue = UnityEngine.Random.Range(0, (_cubeValues.Length - 1));
        _cubeValueOut = _randomDigitForSetCubeValue;
        _maxValue = _cubeValues.Length;

    }

    public void SetCubeValueText(int value)
    {
        for (int i = 0; i < _text.Length; i++)
        {
            _text[i].text = _cubeValues[value].ToString();
        }
    }

    public void SetCubeMaterial(int value)
    {
        _baseMaterial.material = _typeMaterials[value];
    }
}