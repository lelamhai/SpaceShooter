using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuitGameUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Application.Quit();
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
    }
}
