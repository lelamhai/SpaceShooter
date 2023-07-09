using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : BaseAttack
{
    protected override void SpawnBullet()
    {
        SpawnBulletEnemy.Instance.SpawnGameObject(TypeBulletEnemy.RedBulletEnemy.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {
        _durationDelayShooting = 3f;
    }
}
