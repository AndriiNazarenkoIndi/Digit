using System;
using UnityEngine.UI;

public class UIButtonAddRemoveListener
{
    public void ButtonAddListener(Button button, Action onClickAction)
    {
        if (button != null && onClickAction != null)
        {
            button.onClick.AddListener(() => onClickAction?.Invoke());
        }
    }

    public void ButtonRemoveListener(Button button, Action onClickAction)
    {
        if (button != null && onClickAction != null)
        {
            button.onClick.RemoveListener(() => onClickAction?.Invoke());
        }
    }
}