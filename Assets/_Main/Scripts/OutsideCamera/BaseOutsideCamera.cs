using UnityEngine;

public abstract class BaseOutsideCamera : BaseMonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        var target = collision.GetComponent<BaseTag>();
        if(target == null) return;

        if (target._TagGameObject == Tag.Screen)
        {
            OutsideCamera();
            DisableGameObject();
        }
    }

    protected abstract void OutsideCamera();

    private void DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }

    protected override void SetDefaultValue()
    {}
}
