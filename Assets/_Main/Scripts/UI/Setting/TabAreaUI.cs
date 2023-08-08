using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabAreaUI : BaseMonoBehaviour
{
    [SerializeField] private List<TabButtonUI> _listTabButton = new List<TabButtonUI>();
    [SerializeField] private Sprite _spriteEnable;
    [SerializeField] private Sprite _spriteDisanble;

    private void OnEnable()
    {
        TabUI.Instance._ChangeTab += ChangeTab;
    }

    private void OnDisable()
    {
        TabUI.Instance._ChangeTab -= ChangeTab;
    }

    private void ChangeTab(int index)
    {
        DisanbleTabButton(index);
    }

    public void DisanbleTabButton(int index)
    {
        for (int i = 0; i < _listTabButton.Count; i++)
        {
            if (index == i)
            {
                _listTabButton[i].GetComponent<Image>().sprite = _spriteEnable;
            }
            else
            {
                _listTabButton[i].GetComponent<Image>().sprite = _spriteDisanble;
            }
        }
    }

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
            TabButtonUI tabButton = item.GetComponent<TabButtonUI>();
            _listTabButton.Add(tabButton);
        }
    }
}