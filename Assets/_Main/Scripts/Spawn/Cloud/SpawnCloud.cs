using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCloud
{
    Cloud1,
    Cloud2,
    Cloud3,
    Cloud4
}

public class SpawnCloud : BaseSpawn
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
    {
    }
}
