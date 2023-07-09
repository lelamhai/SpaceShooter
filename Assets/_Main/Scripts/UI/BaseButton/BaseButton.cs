using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : BaseMonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        UIManager.Instance.SetPanelStage(TypePanelUI.GamePlay, this.gameObject);
        GameManager.Instance.SetGameStage(GameStates.GamePlay);
    }

    protected override void SetDefaultValue()
    {}


}
