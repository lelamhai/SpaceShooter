using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBulletEnemy : BaseHealth
{
    protected override void DeadGameObject()
    {
        base.DeadGameObject();
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
    }

    protected override void SetDefaultValue()
    {}
}
