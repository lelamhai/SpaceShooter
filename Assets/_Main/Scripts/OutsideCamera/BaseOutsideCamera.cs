using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseOutsideCamera : BaseMonoBehaviour
{
    public void CollisionExit2D()
    {
        DisappearGameObject();
        Disappear();
    }

    protected abstract void DisappearGameObject();

    private void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    protected override void SetDefaultValue()
    {}
}
