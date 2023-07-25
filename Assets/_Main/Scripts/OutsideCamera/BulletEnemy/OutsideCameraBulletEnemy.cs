using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraBulletEnemy : BaseOutsideCamera
{
    protected override void DisappearGameObject()
    {
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
    }
}
