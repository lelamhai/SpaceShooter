using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearEnemy : BaseDisappear
{
    protected override void DisappearGameObject()
    {
        SpawnEnemy.Instance.AddGameObjectPool(this.transform);
    }
}
