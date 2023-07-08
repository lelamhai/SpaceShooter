using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageBulletEnemy : BaseReceiveDamage
{
    protected override void DeadGameObject()
    {
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
        gameObject.SetActive(false);
    }

    protected override void SetDefaultValue()
    {}
}
