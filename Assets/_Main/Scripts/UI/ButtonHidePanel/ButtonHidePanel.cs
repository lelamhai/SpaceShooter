using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHidePanel : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
    }
}
