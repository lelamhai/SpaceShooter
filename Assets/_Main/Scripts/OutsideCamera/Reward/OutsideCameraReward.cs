using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraReward : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
    }
}
