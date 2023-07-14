using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBGAudioUI : BaseSlider
{
    [SerializeField] private AudioSO _audioSO;

    public override void ValueChangeCheck()
    {
        _audioSO._volume = _slider.value;
        AudioManager.Instance.BGAudio(_slider.value);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAudioSO();
    }

    private void LoadAudioSO()
    {
        string path = "Audio/BGAudioSO";
        this._audioSO = Resources.Load<AudioSO>(path);
    }

    
}
