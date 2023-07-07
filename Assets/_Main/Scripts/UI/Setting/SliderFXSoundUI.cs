using UnityEngine;
using UnityEngine.UI;

public class SliderFXSoundUI : BaseMonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private FXSoundSO _fXSoundSO;

    private void Start()
    {
        _slider.value = _fXSoundSO.Volume;
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        _fXSoundSO.Volume = _slider.value;
    }

    protected override void SetDefaultValue()
    { }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _slider = this.GetComponent<Slider>();
    }
}
