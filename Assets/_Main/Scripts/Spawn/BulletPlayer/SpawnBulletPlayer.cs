using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBulletPlayer
{
    RedBulletPlayer
}

public class SpawnBulletPlayer : SingletonSpawn<SpawnBulletPlayer>
{
    private void OnEnable()
    {
        GameManager.Instance._StopGame += StopGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StopGame -= StopGame;
    }

    private void StopGame()
    {
        _baseHolders.DisableAllGameObject();
    }

    protected override void SetDefaultValue()
    {}
}
