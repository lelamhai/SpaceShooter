using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRestartUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Time.timeScale = 1;

        GameManager.Instance.SetGameState(GameStates.StopGame);
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.LoadingGame, PanelState.Show);
    }
}
