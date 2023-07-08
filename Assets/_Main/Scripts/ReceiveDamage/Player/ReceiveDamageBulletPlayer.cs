using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageBulletPlayer : BaseReceiveDamage
{
    protected override void DeadGameObject()
    {
        SpawnBulletPlayer.Instance.AddGameObjectPool(this.transform);
        gameObject.SetActive(false);
    }

    protected override void SetDefaultValue()
    {}
}
