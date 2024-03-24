using UnityEngine;

public class SoundPlayManager : MonoBehaviour
{
    [Header("Audio setting")]
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private SoundList _soundList;

    public void ExsplosionSoundPlay()
    {
        _audioManager.SoundSystemPlay.ExsplosionSoundPlay(_soundList.ExplosionSound);
    }

    public void CubeClickSoundPlay()
    {
        _audioManager.SoundSystemPlay.CubeClickSoundPlay(_soundList.CubeClickSound);
    }

    public void GameOverSoundPlay()
    {
        _audioManager.SoundSystemPlay.GameOverSoundPlay(_soundList.GameOverSound);
    }

    public void ButtonClickSoundPlay()
    {
        _audioManager.SoundSystemPlay.ButtonClickSoundPlay(_soundList.ButtonClickSound);
    }
}