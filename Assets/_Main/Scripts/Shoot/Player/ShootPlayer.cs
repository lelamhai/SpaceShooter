using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : BaseAttack
{
    [SerializeField] private TypeBulletPlayer _currentBullet = TypeBulletPlayer.RedBulletPlayer;

    private void OnEnable()
    {
        GameManager.Instance._StartGame += StartGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame += StartGame;
    }

    private void StartGame()
    {
        _canShoot = true;
    }

    protected override void SpawnBullet()
    {
        SpawnBulletPlayer.Instance.SpawnGameObject(_currentBullet.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {
        _canShoot = false;
        _durationDelayShooting = 0.5f;
    }
}
