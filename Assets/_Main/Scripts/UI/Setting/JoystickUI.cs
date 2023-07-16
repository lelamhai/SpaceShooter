using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickUI : BaseMonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void Start()
    {
        _toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(_toggle);
        });
    }

    public void SetToggleJoystick(bool active)
    {
        _toggle.isOn = active;
    }

    public void ToggleValueChanged(Toggle change)
    {
        UIManager.Instance.SetJoystick(change.isOn);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadToggle();
    }

    private void LoadToggle()
    {
        _toggle = this.GetComponent<Toggle>();
    }
}
