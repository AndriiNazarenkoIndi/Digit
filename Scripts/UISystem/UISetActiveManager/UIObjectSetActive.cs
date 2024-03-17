using UnityEngine;
using UnityEngine.UI;

public class UIObjectSetActive
{
    public void UIGameObjectSetActive(GameObject uiObject, bool isActive)
    {
        uiObject.SetActive(isActive);
    }

    public void UIGameObjectSetActive(UIPanel uiPanel, bool isActive)
    {
        uiPanel.gameObject.SetActive(isActive);
    }

    public void UIGameObjectSetActive(Slider slider, bool isActive)
    {
        slider.gameObject.SetActive(isActive);
    }
}