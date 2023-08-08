using UnityEngine;

public class ButtonResumeUI : BaseButton
{
    protected override void TaskOnClick()
    {
        Time.timeScale = 1;
        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
    }
}