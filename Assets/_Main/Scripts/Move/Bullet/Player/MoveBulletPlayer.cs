using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletPlayer : BaseMove
{
    protected override void SetDefaultValue()
    {
        _direction = Vector3.up;
        _moveSpeed = 1f;
    }
}
