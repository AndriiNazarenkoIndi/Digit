using UnityEngine;

public class SaveLoadManagerSoundSetting : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;

    private ISave _soundSettingSaveSystem;
    private ILoad _soundSettingLoadSystem;

    private void Awake()
    {
        AwakeInitSaveLoadSystem(_soundManager);
        LoadSoundSetting();
    }

    private void AwakeInitSaveLoadSystem(SoundManager soundManager)
    {
        if (soundManager != null)
        {
            _soundSettingSaveSystem = new SoundSettingSaveSystem(soundManager);
            _soundSettingLoadSystem = new SoundSettingLoadSystem(soundManager);
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