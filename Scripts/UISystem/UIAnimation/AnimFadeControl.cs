using UnityEngine;

public class AnimFadeControl : MonoBehaviour
{
    [SerializeField] private UIPanel _fadePanel;
    [SerializeField] private UIFadeScreenAnim _uiFadeScreenAnim;

    private void Awake()
    {
        StartGameScreenAnim();
    }

    private void StartGameScreenAnim()
    {
        _uiFadeScreenAnim.AppearanceScreen(_fadePanel, () => FadePanelSetActive(false));
    }

    private void FadePanelSetActive(bool active)
    {
        _fadePanel.gameObject.SetActive(active);
    }
}