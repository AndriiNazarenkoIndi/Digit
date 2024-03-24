using UnityEngine;

[CreateAssetMenu(fileName = "SoundMusicVolumeSetting", menuName = "Settings/MusicSoundSetting")]
public class SoundMusicVolumeSetting : ScriptableObject
{
    [SerializeField][Range(0.0f, 1.0f)] private float _soundVolumeValue = 0.7f;
    [SerializeField][Range(0.0f, 1.0f)] private float _musicVolumeValue = 0.3f;

    public float SoundVolumeValue => _soundVolumeValue;
    public float MusicVolumeValue => _musicVolumeValue;
}