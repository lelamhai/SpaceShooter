using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBulletEnemy : BaseDisappear
{
    protected override void DisappearGameObject()
    {
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
    }
}
