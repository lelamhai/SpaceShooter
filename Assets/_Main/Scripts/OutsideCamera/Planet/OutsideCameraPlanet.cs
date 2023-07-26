using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraPlanet : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
