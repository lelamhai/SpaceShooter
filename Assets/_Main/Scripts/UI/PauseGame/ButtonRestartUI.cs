using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRestartUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Time.timeScale = 1;
        Debug.Log("ButtonRestartUI");
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
        GameManager.Instance.SetGameState(GameStates.ResetGame);
    }
}
