using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPauseUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Time.timeScale = 0;
        UIManager.Instance.SetPanelState(TypePanelUI.PauseGame, PanelState.Show);
    }
}
