using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextLevel : BaseButton
{
    protected override void TaskOnClick()
    {
        GameManager.Instance.SetGameState(GameStates.StopGame);
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.LoadingGame, PanelState.Show);
    }
}
