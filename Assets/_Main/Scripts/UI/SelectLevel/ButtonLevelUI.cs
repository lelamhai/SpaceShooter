using TMPro;
using UnityEngine;

public class ButtonLevelUI : BaseButton
{
    [SerializeField] private TMP_Text _text;

    protected override void TaskOnClick()
    {
        GameManager.Instance.SelectLevel(this.transform.GetSiblingIndex());

        UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
        UIManager.Instance.SetPanelState(TypePanelUI.LoadingGame, PanelState.Show);
    }

    public void SetTextLevel(string text)
    {
        _text.text = text;
    }

    public void SetInteractable(bool active)
    {
        _button.interactable = active;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    private void LoadText()
    {
        _text = this.transform.Find("Text").GetComponent<TMP_Text>();
    }
}