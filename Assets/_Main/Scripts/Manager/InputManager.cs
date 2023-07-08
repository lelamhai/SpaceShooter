using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    public UnityAction<Vector3> _Movement;

    public void Movement(Vector3 pos)
    {
        _Movement?.Invoke(pos);
    }

    protected override void SetDefaultValue()
    {}
}
