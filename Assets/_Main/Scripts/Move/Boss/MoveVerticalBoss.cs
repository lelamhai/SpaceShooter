using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVerticalBoss : BaseMove
{
    protected override void Movement(Vector3 pos)
    {
        this.transform.Translate(pos * _moveSpeed * Time.deltaTime);

        if (-ScreenWidthHeight.Instance._HeightCamera / 2 > this.transform.position.y)
        {
            _direction = Vector3.up;
        }
        else if (ScreenWidthHeight.Instance._HeightCamera / 2 < this.transform.position.y)
        {
            _direction = Vector3.down;
        }
    }

    protected override void SetDefaultValue()
    {
        _direction = Vector3.down;
    }
}
