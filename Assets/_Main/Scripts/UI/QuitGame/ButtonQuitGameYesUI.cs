using UnityEngine;

public class ButtonQuitGameYesUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
        Application.Quit();
    }
}