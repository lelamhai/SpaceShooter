using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseOutsideCamera : BaseMonoBehaviour
{
    public void CollisionExit2D()
    {
        OutsideCamera();
        Disappear();
    }

    protected abstract void OutsideCamera();

    private void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    protected override void SetDefaultValue()
    {}
}
