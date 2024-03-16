using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityAction _OnPointerDownEvent;
    public UnityAction<float> _OnPointerDragEvent;
    public UnityAction _OnPointerUpEvent;

    private Slider _slider;

    void Awake()
    {
        InitSlider();
    }

    private void InitSlider()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(OnSliderChangerValue);
        ZeroingSliderValue();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_OnPointerDownEvent != null)
        {
            _OnPointerDownEvent.Invoke();
        }
        if (_OnPointerDragEvent != null)
        {
            _OnPointerDragEvent.Invoke(_slider.value);
        }
    }

    public void OnSliderChangerValue(float value)
    {
        if (_OnPointerDragEvent != null)
        {
            _OnPointerDragEvent.Invoke(value);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_OnPointerUpEvent != null)
        {
            _OnPointerUpEvent.Invoke();
        }
        ZeroingSliderValue();
    }

    private void OnDestroy()
    {
        _slider.onValueChanged.RemoveListener(OnSliderChangerValue);
    }

    private void ZeroingSliderValue()
    {
        _slider.value = 0.0f;
    }
}