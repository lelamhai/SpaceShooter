using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggables : Singleton<Draggables>
{
    private Transform _point;
    public Transform _Point => _point;

    protected override void SetDefaultValue()
    {}
}
