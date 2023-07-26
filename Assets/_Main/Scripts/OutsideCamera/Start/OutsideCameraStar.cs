using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraStar : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnStar.Instance.AddGameObjectPool(this.transform);
    }
}
