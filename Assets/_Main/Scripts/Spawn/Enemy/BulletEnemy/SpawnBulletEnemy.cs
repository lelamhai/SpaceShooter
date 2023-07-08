using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBulletEnemy
{
    RedBulletEnemy
}

public class SpawnBulletEnemy : SingletonSpawn<SpawnBulletEnemy>
{
    protected override void SetDefaultValue()
    { }
}
