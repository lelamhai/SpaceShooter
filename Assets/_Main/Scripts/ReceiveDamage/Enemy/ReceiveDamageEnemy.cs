using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamageEnemy : BaseReceiveDamage
{
    protected override void DeadGameObject()
    {
        SpawnEnemy.Instance.AddGameObjectPool(this.transform);
        gameObject.SetActive(false);
    }

    protected override void SetDefaultValue()
    {
    }
}
