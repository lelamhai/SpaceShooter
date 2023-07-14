using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResumeUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Time.timeScale = 1;
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
    }
}
