using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;

    private void OnEnable()
    {
        UIManager.Instance._Joystick += SetActiveJoystick;
    }

    private void OnDisable()
    {
        UIManager.Instance._Joystick -= SetActiveJoystick;
    }

    private void SetActiveJoystick(bool active)
    {
        _joystick.SetActive(active);
    }
}
