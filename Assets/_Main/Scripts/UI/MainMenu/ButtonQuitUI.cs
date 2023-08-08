public class ButtonQuitUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.QuitGame, PanelState.Show);
    }
}