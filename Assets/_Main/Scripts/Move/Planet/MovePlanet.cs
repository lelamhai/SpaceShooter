using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlanet : BaseMove
{
    protected override void SetDefaultValue()
    {
        _direction = Vector3.down;
        _moveSpeed = 0.2f;
    }
}
