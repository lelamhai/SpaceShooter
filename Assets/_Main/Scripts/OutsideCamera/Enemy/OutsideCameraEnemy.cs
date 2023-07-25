using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraEnemy : BaseOutsideCamera
{
    protected override void DisappearGameObject()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
