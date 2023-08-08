using System.Collections.Generic;
using UnityEngine;

public class PageAreaUI : BaseMonoBehaviour
{
    [SerializeField] private List<Transform> _listPage = new List<Transform>();

    private void OnEnable()
    {
        TabUI.Instance._ChangeTab += ChangePage;
    }

    private void OnDisable()
    {
        TabUI.Instance._ChangeTab -= ChangePage;
    }

    private void ChangePage(int index)
    {
        DisanblePage(index);
    }

    private void DisanblePage(int index)
    {
        for (int i = 0; i < _listPage.Count; i++)
        {
            if(index == i)
            {
                _listPage[i].gameObject.SetActive(true);
            } else
            {
                _listPage[i].gameObject.SetActive(false);
            }
        }
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAllPage();
    }

    private void LoadAllPage()
    {
        Transform pages = this.transform;

        foreach (Transform item in pages)
        {
            _listPage.Add(item);
        }
    }
}