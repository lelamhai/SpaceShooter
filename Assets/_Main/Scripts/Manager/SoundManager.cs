using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;
    [SerializeField] private Slider _soundBG;
    [SerializeField] private Slider _soundFX;

    public void PlaySound(AudioClip audioClip)
    {
        _effectSource.PlayOneShot(audioClip);
    }

    //public void AllAudio(float value)
    //{
    //    BGAudio(value);
    //    FXAudio(value);
    //    _soundBG.value = value;
    //    _soundFX.value = value;
    //}

    public void BGAudio(float value)
    {
        _musicSource.volume = value;
    }

    public void FXAudio(float value)
    {
        _effectSource.volume = value;
    }

    protected override void SetDefaultValue()
    {
    }
}
