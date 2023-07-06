using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _shotting;

    private void OnEnable()
    {
        UIManager.Instance._AutoShootingUI += SetActiveShooting;
        UIManager.Instance._Joystick += SetActiveJoystick;
    }

    private void OnDisable()
    {
        UIManager.Instance._AutoShootingUI -= SetActiveShooting;
        UIManager.Instance._Joystick -= SetActiveJoystick;
    }

    private void SetActiveShooting(bool active)
    {
        _shotting.SetActive(!active);
    }

    private void SetActiveJoystick(bool active)
    {
        _joystick.SetActive(active);
    }
}
