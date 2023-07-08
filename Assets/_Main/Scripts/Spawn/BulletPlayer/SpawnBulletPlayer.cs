using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBulletPlayer
{
    RedBulletPlayer
}

public class SpawnBulletPlayer : SingletonSpawn<SpawnBulletPlayer>
{
    protected override void SetDefaultValue()
    {}
}
