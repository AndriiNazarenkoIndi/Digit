using UnityEngine;
using UnityEngine.UI;

public class UISoundManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private SoundList _soundList;

    [Header("Sound on tap (Buttons)")]
    [SerializeField] private Button[] _buttons;

    private UIButtonAddRemoveListener _uiButtonAddRemoveListener = new UIButtonAddRemoveListener();

    private void Start()
    {
        ButtonOnClickAddListener();
    }

    private void ButtonOnClickAddListener()
    {
        foreach (Button button in _buttons)
        {
            _uiButtonAddRemoveListener.ButtonAddListener(button, PlayButtonClickSound);
        }
    }
    private void ButtonOnClickRemoveListener()
    {
        foreach (Button button in _buttons)
        {
            _uiButtonAddRemoveListener.ButtonRemoveListener(button, PlayButtonClickSound);
        }
    }

    private void PlayButtonClickSound()
    {
        if (_audioManager != null)
        {
            _audioManager.SoundSystemPlay.ButtonClickSoundPlay(_soundList.ButtonClickSound);
        }
    }

    private void OnDestroy()
    {
        ButtonOnClickRemoveListener();
    }
}