using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEffect
{
    EffectEnemy
}

public class SpawnEffect : SingletonSpawn<SpawnEffect>
{
    protected override void SetDefaultValue()
    {}
}
