using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingGameUI : BaseMonoBehaviour
{
    [SerializeField] private JoystickUI _joystickUI;
    [SerializeField] private JoystickSO _joystickSO;
    private void OnEnable()
    {
        _joystickUI.SetToggleJoystick(_joystickSO._userJoystick);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadJoyStick();
        LoadJoystickSO();
    }

    private void LoadJoyStick()
    {
        _joystickUI = GameObject.Find("ToggleJoystick").GetComponent<JoystickUI>();
    }

    private void LoadJoystickSO()
    {
        string path = "Joystick/JoystickSO";
        _joystickSO = Resources.Load<JoystickSO>(path);
    }
}
