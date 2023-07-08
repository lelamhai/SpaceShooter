using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : BaseAttack
{
    [SerializeField] private TypeBulletPlayer _currentBullet = TypeBulletPlayer.RedBulletPlayer;

    protected override void SpawnBullet()
    {
        SpawnBulletPlayer.Instance.SpawnGameObject(_currentBullet.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {}
}
