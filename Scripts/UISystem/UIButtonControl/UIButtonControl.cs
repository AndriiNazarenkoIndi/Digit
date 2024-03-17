using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButtonControl : MonoBehaviour
{
    [SerializeField] private Button _uiButton;

    public UnityEvent EventOnClick;

    private UIButtonAddRemoveListener _uiButtonAddRemoveListener = new UIButtonAddRemoveListener();

    private void Start()
    {
        SubscribeButtonOnClickEvent();
    }

    private void SubscribeButtonOnClickEvent()
    {
        _uiButtonAddRemoveListener.ButtonAddListener(_uiButton, ButtonOnClickInvokeEvent);
    }

    private void UnsubscribeButtonOnClickEvent()
    {
        _uiButtonAddRemoveListener.ButtonRemoveListener(_uiButton, ButtonOnClickInvokeEvent);
    }

    private void ButtonOnClickInvokeEvent()
    {
        EventOnClick?.Invoke();
    }

    private void OnDestroy()
    {
        UnsubscribeButtonOnClickEvent();
    }
}