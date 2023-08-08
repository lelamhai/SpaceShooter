using UnityEngine;
using UnityEngine.UI;

public class TabButtonUI : BaseMonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _spriteEnable;

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        TabUI.Instance.ChangeTab(transform.GetSiblingIndex());
        _button.GetComponent<Image>().sprite = _spriteEnable;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadButton();
    }

    private void LoadButton()
    {
        _button = this.GetComponent<Button>();
    }
}