using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectMapUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.SelectLevel, PanelState.Show);
    }
}
