using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMapUI : BaseMonoBehaviour
{
    [SerializeField] private GameObject _gridLevel;
    [SerializeField] private ButtonLevelUI _buttonLevel;

    private void OnEnable()
    {
        LoadLevel();
    }

    private void OnDisable()
    {
        RemoveButtonLevel();
    }

    private void LoadLevel()
    {
        for (int i = 0; i < LevelManager.Instance._CountLevel; i++)
        {
            ButtonLevelUI level = Instantiate(_buttonLevel);
            level.transform.SetParent(_gridLevel.transform);
            level.SetTextLevel((i + 1).ToString());
            if(LevelManager.Instance._CurrentLevel >= i)
            {
                level.SetInteractable(true);
            }
        }
    }

    private void RemoveButtonLevel()
    {
        var list = _gridLevel.transform;
        foreach (Transform item in list)
        {
            Destroy(item.gameObject);
        }
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGrid();
    }

    private void LoadGrid()
    {
        _gridLevel = GameObject.Find("GridLevel").gameObject;
    }
}
