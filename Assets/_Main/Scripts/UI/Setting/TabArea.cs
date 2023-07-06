using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabArea : BaseMonoBehaviour
{
    [SerializeField] private List<TabButton> _listTabButton = new List<TabButton>();
    [SerializeField] private TabButton _selectedTabButton;

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTabButton();
    }

    private void LoadTabButton()
    {
        Transform parent = this.transform;
        foreach (Transform item in parent)
        {
            TabButton tabButton = item.GetComponent<TabButton>();
            _listTabButton.Add(tabButton);
        }
    }
}
