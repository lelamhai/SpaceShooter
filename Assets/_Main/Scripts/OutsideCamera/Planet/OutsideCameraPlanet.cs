using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraPlanet : BaseOutsideCamera
{
    protected override void DisappearGameObject()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
