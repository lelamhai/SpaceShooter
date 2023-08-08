using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveReward : BaseMove
{
    protected override void SetDefaultValue()
    {
        _direction = Vector3.down;
        _moveSpeed = 0.5f;
    }
}
