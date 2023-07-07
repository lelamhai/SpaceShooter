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
        _toggle.isOn = _muteSO.Mute;

        _toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(_toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        _muteSO.Mute = change.isOn;
    }

    protected override void SetDefaultValue()
    { }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _toggle = this.GetComponent<Toggle>();
    }
}
