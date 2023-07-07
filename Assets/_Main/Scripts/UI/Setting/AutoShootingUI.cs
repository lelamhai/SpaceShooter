using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoShootingUI : BaseMonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private AutoShootingSO _autoShootingSO;

    private void Start()
    {
        _toggle.isOn = _autoShootingSO.AutoShooting;
        _toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(_toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        UIManager.Instance.AutoShooting(change.isOn);
        _autoShootingSO.AutoShooting = change.isOn;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _toggle = this.GetComponent<Toggle>();
    }
}
