using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEnemy : BaseImpact
{
    protected override void DeadGameObject(Transform transform)
    {
        base.DeadGameObject(transform);
        transform.gameObject.SetActive(false);
    }
}
