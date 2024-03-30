using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeScreenAnim : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] [Range(0, 5)] private float _animDuration = 1.0f;

    private float _startAlphaValue = 0f;
    private float _endAlphaValue = 1f;

    private Color _startColor;

    public void FadeScreen(UIPanel uiPanel, Action OnCompleteAnimation)
    {
        ScreenFadeAnim(_startAlphaValue, _endAlphaValue, uiPanel, OnCompleteAnimation);
    }

    public void AppearanceScreen(UIPanel uiPanel, Action OnCompleteAnimation)
    {
        ScreenFadeAnim(_endAlphaValue, _startAlphaValue, uiPanel, OnCompleteAnimation);
    }

    private void ScreenFadeAnim(float startAlphaValue, float endAlphaValue, UIPanel uiPanel, Action OnCompleteAnimation)
    {
        if (_fadeImage != null)
        {
            _startColor = _fadeImage.color;
            _startColor.a = startAlphaValue;
            _fadeImage.color = _startColor;
            _fadeImage.DOFade(endAlphaValue, _animDuration).OnComplete(() => OnCompleteAnimation());
        }
    }
}