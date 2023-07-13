using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBulletPlayer : BaseHealth
{
    protected override void DeadGameObject()
    {
        base.DeadGameObject();
        SpawnBulletPlayer.Instance.AddGameObjectPool(this.transform);
    }

    protected override void SetDefaultValue()
    {}
}
