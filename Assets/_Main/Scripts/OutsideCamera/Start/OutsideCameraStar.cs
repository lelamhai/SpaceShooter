using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraStar : BaseOutsideCamera
{
    protected override void DisappearGameObject()
    {
        SpawnStar.Instance.AddGameObjectPool(this.transform);
    }
}
