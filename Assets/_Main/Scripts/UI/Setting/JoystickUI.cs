using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickUI : BaseMonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private JoystickSO _joystickSO;

    private void Start()
    {
        _toggle.isOn = _joystickSO.ShowJoystick;
        _toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(_toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        UIManager.Instance.Joystick(change.isOn);
        _joystickSO.ShowJoystick = change.isOn;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _toggle = this.GetComponent<Toggle>();
    }
}
