using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : BaseMonoBehaviour
{
    [SerializeField] private GameObject _joystick;
    [SerializeField] private JoystickSO _joystickSO;

    private void OnEnable()
    {
        _joystick.SetActive(_joystickSO._userJoystick);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadJoystick();
        LoadJoystickSO();
    }

    private void LoadJoystick()
    {
        _joystick = GameObject.Find("Joystick").gameObject;
    }

    private void LoadJoystickSO()
    {
        string path = "Joystick/JoystickSO";
        _joystickSO = Resources.Load<JoystickSO>(path);
    }
}
