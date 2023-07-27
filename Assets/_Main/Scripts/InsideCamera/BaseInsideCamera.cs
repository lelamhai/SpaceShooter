using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInsideCamera : BaseMonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<BaseTag>();
        if (target == null) return; 
        if (target.GetTagGameObject() != Tag.Screen) return;
        
        InsideCamera();
    }

    protected abstract void InsideCamera();

    protected override void SetDefaultValue()
    {}
}
