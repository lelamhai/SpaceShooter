using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotkeyUI : Singleton<HotkeyUI>
{
    [SerializeField] private Transform _holder;
    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadHolder();
    }

    private void LoadHolder()
    {
        _holder = this.transform.Find("Holders");
    }
}
