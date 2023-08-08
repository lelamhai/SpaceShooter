using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : BaseMove
{
    protected override void SetDefaultValue()
    {
        _moveSpeed = 2f;
        _direction = Vector3.down;
    }
}
