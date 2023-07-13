using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : BaseHealth
{
    private void OnEnable()
    {
        _model.color = Color.white;
    }

    protected override void DeadGameObject()
    {
        base.DeadGameObject();
        SpawnEnemy.Instance.AddGameObjectPool(this.transform);
    }

    protected override void HitGameObject()
    {
        base.HitGameObject();
        StartCoroutine(IEHitGameObject());
    }

    private IEnumerator IEHitGameObject()
    {
        _model.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        _model.color = Color.white;
    }

    protected override void SetDefaultValue()
    {}
}
