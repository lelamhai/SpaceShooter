public class ButtonSettingUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.SettingGame, PanelState.Show);
    }
}