using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCameraBulletPlayer : BaseOutsideCamera
{
    protected override void DisappearGameObject()
    {
        SpawnBulletPlayer.Instance.AddGameObjectPool(this.transform);
    }
}
