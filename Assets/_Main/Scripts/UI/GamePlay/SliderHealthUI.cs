using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHealthUI : BaseSlider
{
    private void OnEnable()
    {
        UIManager.Instance._HealthPlayer += SetHealthPlayer;
    }

    private void OnDisable()
    {
        UIManager.Instance._HealthPlayer -= SetHealthPlayer;
    }

    private void SetHealthPlayer(int currentHealth, int maxhealth)
    {
        _slider.value = (currentHealth * _slider.maxValue) / maxhealth;
    }

    public override void ValueChangeCheck()
    {}
}
