using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStartGame : BaseMove
{
    protected override void Movement(Vector3 pos)
    {
        if (this.transform.position.y < -3f)
        {
            return;
        }
        this.transform.Translate(pos * 10f * Time.deltaTime);
    }

    protected override void SetDefaultValue()
    {
        _direction = Vector3.up;
    }
}
