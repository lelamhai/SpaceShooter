using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : BaseMonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(TaskOnClick);
    }

    protected abstract void TaskOnClick();

    protected override void SetDefaultValue()
    {}


}
