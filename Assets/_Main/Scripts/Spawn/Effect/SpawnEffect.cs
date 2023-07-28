using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEffect
{
    EffectEnemy
}

public class SpawnEffect : SingletonSpawn<SpawnEffect>
{
    private void OnEnable()
    {
        GameManager.Instance._Initialize += Initialize;
    }

    private void OnDisable()
    {
        GameManager.Instance._Initialize -= Initialize;
    }

    private void Initialize()
    {
        _baseHolders.DisableAllGameObject();
    }

    protected override void SetDefaultValue()
    {}
}
