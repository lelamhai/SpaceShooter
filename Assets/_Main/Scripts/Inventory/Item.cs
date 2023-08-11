using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : BaseMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _oldParent = null;
    [SerializeField] private Image _avatar;
    public Transform _OldParent
    {
        get => _oldParent;
        set => _oldParent = value;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RememberParent();
        SetParent(HotkeyUI.Instance.transform);
        RaycastTarget(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastTarget(true);
        if (eventData.pointerEnter == null)
        {
            this.gameObject.SetActive(false);
            return;
        }

        TagInventory tag = eventData.pointerEnter.GetComponent<TagInventory>();
        if(tag == null)
        {
            this.gameObject.SetActive(false);
            return;
        }
    }

    private void RememberParent()
    {
        _oldParent = this.transform.parent;
    }

    private void SetParent(Transform parent)
    {
        this.transform.SetParent(parent);
    }

    private void RaycastTarget(bool active)
    {
        _avatar.raycastTarget = active;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAvatar();
    }

    private void LoadAvatar()
    {
        _avatar = this.GetComponent<Image>();
    }
}
