using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenuUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Time.timeScale = 1;
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.GamePlay, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.MainMenu, PanelState.Show);
        GameManager.Instance.SetGameState(GameStates.StopGame);
    }
}
