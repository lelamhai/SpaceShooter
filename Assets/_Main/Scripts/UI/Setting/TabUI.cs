using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabUI : Singleton<TabUI>
{
    public UnityAction<int> _ChangeTab;
    private int _currentIndex = -1;
    private void Start()
    {
        ChangeTab(0);
    }

    public void ChangeTab(int index)
    {
        if (_currentIndex == index) return;
        _ChangeTab?.Invoke(index);
        _currentIndex = index;
    }

    protected override void SetDefaultValue()
    {}
}
