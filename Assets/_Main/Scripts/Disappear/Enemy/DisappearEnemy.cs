using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearEnemy : BaseDisappear
{
    protected override void DisappearGameObject()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
