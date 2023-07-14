using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGameUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.MainMenu, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.GamePlay, PanelState.Show);
        GameManager.Instance.SetGameState(GameStates.StartGame);
    }
}
