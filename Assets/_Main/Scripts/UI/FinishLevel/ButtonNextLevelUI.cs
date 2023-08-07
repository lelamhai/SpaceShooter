using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextLevelUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);

        if(LevelManager.Instance._FinishGame)
        {
            UIManager.Instance.SetPanelState(TypePanelUI.FinishGame, PanelState.Show);
            return;
        }

        UIManager.Instance.SetPanelState(TypePanelUI.SelectLevel, PanelState.Show);
    }
}
