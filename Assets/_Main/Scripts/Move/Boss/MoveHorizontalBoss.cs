using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontalBoss : BaseMove
{
    protected override void Movement(Vector3 pos)
    {
        this.transform.Translate(pos * _moveSpeed * Time.deltaTime);

        if(-ScreenWidthHeight.Instance._WidthCamera / 2 > this.transform.position.x)
        {
            _direction = Vector3.right;
        } else if(ScreenWidthHeight.Instance._WidthCamera / 2 < this.transform.position.x)
        {
            _direction = Vector3.left;
        }
    }

    protected override void SetDefaultValue()
    {
        _direction = Vector3.left;
    }
}
