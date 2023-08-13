public class ButtonSelectMapUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.LevelSelect, PanelState.Show);
    }
}