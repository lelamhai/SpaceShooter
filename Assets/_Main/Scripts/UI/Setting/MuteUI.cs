using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUI : BaseMonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private MuteSO _muteSO;

    private void Start()
    {
        LoadValueToggle();
        _toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(_toggle);
        });
    }

    private void LoadValueToggle()
    {
        _toggle.isOn = _muteSO.Mute;
    }

    void ToggleValueChanged(Toggle change)
    {
        _muteSO.Mute = change.isOn;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadToggle();
        LoadMuteSO();
    }

    private void LoadToggle()
    {
        _toggle = this.GetComponent<Toggle>();
    }

    private void LoadMuteSO()
    {
        string path = "Audio/MuteSO";
        this._muteSO = Resources.Load<MuteSO>(path);
    }
}
