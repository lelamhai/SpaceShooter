using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeGameObject
{
    Enemy1,
    Enemy2,
    Boss1,
    Boss2,
    BluePlanet,
    GreenPlanet,
    WhiteStar,
    BlueStar
}

public class SpawnGameObject : SingletonSpawn<SpawnGameObject>
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
