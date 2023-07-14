using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTutorialUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.TutorialGame, PanelState.Show);
    }
}
