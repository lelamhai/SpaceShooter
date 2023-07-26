using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraBulletEnemy : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
    }
}
