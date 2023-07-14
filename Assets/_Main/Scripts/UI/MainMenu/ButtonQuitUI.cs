using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.QuitGame, PanelState.Show);
    }
}
