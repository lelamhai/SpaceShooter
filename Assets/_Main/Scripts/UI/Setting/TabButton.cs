using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButton : BaseMonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private TabArea _tabArea;

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadParent();
    }

    private void LoadParent()
    {
        var parent = this.transform.parent.gameObject;
        _tabArea = parent.GetComponent<TabArea>();
    }
}
