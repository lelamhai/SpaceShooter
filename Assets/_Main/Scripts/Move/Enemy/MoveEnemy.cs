using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : BaseMove
{
    protected override void Movement(Vector3 pos)
    {
        transform.Translate(pos * _moveSpeed * Time.deltaTime);
    }

    protected override void SetDefaultValue()
    {
        _moveSpeed = 2f;
        _direction = Vector3.down;
    }
}
