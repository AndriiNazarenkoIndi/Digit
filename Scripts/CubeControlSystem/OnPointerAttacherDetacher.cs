using UnityEngine;

public class OnPointerAttacherDetacher : MonoBehaviour
{
    [SerializeField] private SliderControl _sliderControl;
    [SerializeField] private CubeController _cubeController;

    private EventAttacherDetacher _eventAttacherDetacher = new EventAttacherDetacher();

    private void Awake()
    {
        AttachSliderEvent();
    }

    private void AttachSliderEvent()
    {
        _eventAttacherDetacher.AttachDetach(_sliderControl, () => _sliderControl._OnPointerDownEvent += _cubeController.OnPointerDown);
        _eventAttacherDetacher.AttachDetach(_sliderControl, () => _sliderControl._OnPointerDragEvent += _cubeController.OnPointerDrag);
        _eventAttacherDetacher.AttachDetach(_sliderControl, () => _sliderControl._OnPointerUpEvent += _cubeController.OnPointerUp);
    }

    private void DetachSliderEvent()
    {
        _eventAttacherDetacher.AttachDetach(_sliderControl, () => _sliderControl._OnPointerUpEvent -= _cubeController.OnPointerUp);
        _eventAttacherDetacher.AttachDetach(_sliderControl, () => _sliderControl._OnPointerDragEvent -= _cubeController.OnPointerDrag);
        _eventAttacherDetacher.AttachDetach(_sliderControl, () => _sliderControl._OnPointerDownEvent -= _cubeController.OnPointerDown);
    }

    private void OnDestroy()
    {
        DetachSliderEvent();
    }
}