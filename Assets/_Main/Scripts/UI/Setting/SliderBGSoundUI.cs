using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBGSoundUI : BaseMonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private BGSoundSO _bGSoundSO;

    private void Start()
    {
        _slider.value = _bGSoundSO.Volume;
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        _bGSoundSO.Volume = _slider.value;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _slider = this.GetComponent<Slider>();
    }
}
