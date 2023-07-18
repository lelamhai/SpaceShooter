using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    public Vector2 _MovePos { get; private set; }

    public void Movement(Vector2 currentPos)
    {
        _MovePos = currentPos;
    }

    protected override void SetDefaultValue()
    {}
}
