using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _bgSource;
    [SerializeField] private AudioSource _effectSource;
    [SerializeField] private Slider _soundBG;
    [SerializeField] private Slider _soundEffect;
    [SerializeField] private AudioSO _audioBGSO;
    [SerializeField] private AudioSO _audioEffectSO;

    private void Start()
    {
        LoadValueSound();
        BGAudio(_audioBGSO._volume);
        EffectAudio(_audioEffectSO._volume);
    }

    private void LoadValueSound()
    {
        _soundBG.value = _audioBGSO._volume;
        _soundEffect.value = _audioEffectSO._volume;
    }

    public void BGAudio(float value)
    {
        _bgSource.volume = value;
    }

    public void EffectAudio(float value)
    {
        _effectSource.volume = value;
    }

    public void BGPlaySound(AudioClip audioClip)
    {
        _bgSource.PlayOneShot(audioClip);
    }

    public void EffectPlaySound(AudioClip audioClip)
    {
        _effectSource.PlayOneShot(audioClip);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAudio();
        LoadSlider();
        LoadAudioBGSO();
        LoadAudioEffectSO();
    }

    private void LoadAudio()
    {
        _bgSource = this.transform.Find("AudioBG").GetComponent<AudioSource>();
        _effectSource = this.transform.Find("AudioEffect").GetComponent<AudioSource>();
    }

    private void LoadSlider()
    {
        _soundBG = GameObject.Find("SliderBGSound").GetComponent<Slider>();
        _soundEffect = GameObject.Find("SliderEffectSound").GetComponent<Slider>();
    }

    private void LoadAudioBGSO()
    {
        string path = "Audio/BGAudioSO";
        this._audioBGSO = Resources.Load<AudioSO>(path);
    }

    private void LoadAudioEffectSO()
    {
        string path = "Audio/EffectAudioSO";
        this._audioEffectSO = Resources.Load<AudioSO>(path);
    }
}
