public class ButtonTutorialUI : BaseButton
{
    protected override void TaskOnClick()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.TutorialGame, PanelState.Show);
    }
}