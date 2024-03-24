using UnityEngine;

public class MusicPlayManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MusicList _musicList;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        _audioManager.MusicSystemPlay.PlayBackgroundMusic(_musicList.BackgroundMusic);
    }
}