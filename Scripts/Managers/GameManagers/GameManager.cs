using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isMainMenu = false;

    [Header("Name scenes")]
    [SerializeField] private string _nameMainMenuScene;
    [SerializeField] private string _nameBaseScene;

    public delegate void GameOverEvent();
    public event GameOverEvent GameOverStatusEvent;

    public UnityEvent GameOverUnityEvent;
    public bool IsMainMenu => _isMainMenu;

    public void GameStop()
    {
        GameOverUnityEvent?.Invoke();
        GameOverStatusEvent?.Invoke();
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(_nameBaseScene))
        {
            SceneManager.LoadScene(_nameBaseScene);
        }
    }

    public void ReturnToMainMenu()
    {
        if (!string.IsNullOrEmpty(_nameMainMenuScene))
        {
            SceneManager.LoadScene(_nameMainMenuScene);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}