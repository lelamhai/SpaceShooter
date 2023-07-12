using UnityEngine;
using UnityEngine.UI;

public class SliderFXSoundUI : BaseSlider
{
    [SerializeField] private AudioSO _audioSO;

    public override void ValueChangeCheck()
    {
        base.ValueChangeCheck();
        _audioSO._volume = _slider.value;
        AudioManager.Instance.EffectAudio(_slider.value);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAudioSO();
    }

    private void LoadAudioSO()
    {
        string path = "Audio/EffectAudioSO";
        this._audioSO = Resources.Load<AudioSO>(path);
    }
}
