using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : BaseHealth
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _model.color = Color.white;
    }

    protected override void DeadGameObject()
    {
        base.DeadGameObject();
        SpawnEnemy.Instance.AddGameObjectPool(this.transform);
        GameManager.Instance.SetGameState(GameStates.EndLevel);
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
    {
        _maxHealth = 10;
    }
}
