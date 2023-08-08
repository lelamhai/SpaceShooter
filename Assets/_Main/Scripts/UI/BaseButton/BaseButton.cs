using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : BaseMonoBehaviour
{
    [SerializeField] protected Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(TaskOnClick);
    }

    protected abstract void TaskOnClick();

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _button = this.GetComponent<Button>();
    }
}
