using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBulletPlayer : BaseDisappear
{
    protected override void DisappearGameObject()
    {
        SpawnBulletPlayer.Instance.AddGameObjectPool(this.transform);
    }
}
