using UnityEngine;

public class CubeTypeDefinition : MonoBehaviour
{
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
        RandomSetCubeValue();
        SetCubeMaterial(_randomDigitForSetCubeValue);
    }
    
    private void GetBaseMaterial()
    {
        _baseMaterial = GetComponent<Renderer>();
    }

    private void RandomSetCubeValue()
    {
        _randomDigitForSetCubeValue = UnityEngine.Random.Range(0, (_cubeValues.Length - 1));
        _cubeValueOut = _randomDigitForSetCubeValue;
        _maxValue = _cubeValues.Length;
    }

    public void SetCubeMaterial(int value)
    {
        _baseMaterial.material = _typeMaterials[value];
    }
}