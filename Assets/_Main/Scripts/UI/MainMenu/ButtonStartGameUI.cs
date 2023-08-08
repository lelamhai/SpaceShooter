public class ButtonStartGameUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.MainMenu, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.LoadingGame, PanelState.Show);
    }
}