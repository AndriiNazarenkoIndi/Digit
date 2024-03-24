using UnityEngine;

public class SaveLoadManagerSoundSetting : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    private ISave _soundSettingSaveSystem;
    private ILoad _soundSettingLoadSystem;

    private void Awake()
    {
        AwakeInitSaveLoadSystem(audioManager);
        LoadSoundSetting();
    }

    private void AwakeInitSaveLoadSystem(AudioManager audioManager)
    {
        if (audioManager != null)
        {
            _soundSettingSaveSystem = new SoundSettingSaveSystem(audioManager);
            _soundSettingLoadSystem = new SoundSettingLoadSystem(audioManager);
        }
    }

    public void LoadSoundSetting()
    {
        if (_soundSettingSaveSystem != null)
        {
            _soundSettingLoadSystem.Load();
        }
        else
        {
            Debug.Log("SoundSettingLoadSystem is Null. Load is Failed.");
        }
    }

    public void SaveSoundSetting()
    {
        if (_soundSettingSaveSystem != null)
        {
            _soundSettingSaveSystem.Save();
        }
        else
        {
            Debug.Log("SoundSettingSaveSystem is Null. Save is Failed.");
        }
    }
}