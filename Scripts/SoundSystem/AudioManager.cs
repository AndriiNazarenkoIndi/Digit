using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio sources")]
    [SerializeField] private AudioSource _audioSourceSound;
    [SerializeField] private AudioSource _audioSourceMusic;

    [Header("Volume setting")]
    [SerializeField] private SoundMusicVolumeSetting _soundMusicVolumeSetting;

    private float _soundVolumeValue = 0.7f;
    private float _musicVolumeValue = 0.3f;

    private SoundPlaySystem _soundPlaySystem;
    private MusicPlaySystem _musicPlaySystem;

    private AudioPlayStatus _soundPlayStatus;
    private AudioPlayStatus _musicPlayStatus;

    private AudioVolumeSetting _soundVolumeSetting;
    private AudioVolumeSetting _musicVolumeSetting;

    private bool _musicStatus = false;
    private bool _soundStatus = false;

    public bool MusicStatus
    {
        get { return _musicStatus; }
        set { _musicStatus = value; }
    }
    public bool SoundStatus
    {
        get { return _soundStatus; }
        set { _soundStatus = value; }
    }

    public SoundPlaySystem SoundSystemPlay => _soundPlaySystem;
    public MusicPlaySystem MusicSystemPlay => _musicPlaySystem;

    private void Awake()
    {
        AudioSystemInit();
        AudioPlayStatusInit();
        AudioVolumeSettingInit();
    }

    private void Start()
    {
        InitSettingSound();
        OnOffMusicPlay();
        OnOffSoundEffectPlay();
    }

    private void AudioSystemInit()
    {
        _soundPlaySystem = new SoundPlaySystem(_audioSourceSound);
        _musicPlaySystem = new MusicPlaySystem(_audioSourceMusic);
    }

    private void AudioPlayStatusInit()
    {
        _soundPlayStatus = new AudioPlayStatus(_audioSourceSound);
        _musicPlayStatus = new AudioPlayStatus(_audioSourceMusic);
    }

    private void AudioVolumeSettingInit()
    {
        if (_soundMusicVolumeSetting != null)
        {
            _soundVolumeValue = _soundMusicVolumeSetting.SoundVolumeValue;
            _musicVolumeValue = _soundMusicVolumeSetting.MusicVolumeValue;
        }
        _soundVolumeSetting = new AudioVolumeSetting(_audioSourceSound);
        _musicVolumeSetting = new AudioVolumeSetting(_audioSourceMusic);
    }

    private void InitSettingSound()
    {
        _soundVolumeSetting.SetVolumeValue(_soundVolumeValue);
        _musicVolumeSetting.SetVolumeValue(_musicVolumeValue);
    }

    #region On/Off Music and Sound
    public void OnOffMusicPlay()
    {
        _musicPlayStatus.SetMuteStatus(_musicStatus);
    }

    public void OnOffSoundEffectPlay()
    {
        _soundPlayStatus.SetMuteStatus(_soundStatus);
    }

    public void MusicStatusInverse()
    {
        _musicStatus = _musicPlayStatus.MuteStatusInverse(_musicStatus);
    }

    public void SoundStatusInverse()
    {
       _soundStatus = _soundPlayStatus.MuteStatusInverse(_soundStatus);
    }

    #endregion
}