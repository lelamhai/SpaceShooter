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
        GameManager.Instance.SetGameState(GameStates.LevelUp);
        GameManager.Instance.SetGameState(GameStates.EndLevel);
        var effect = SpawnEffect.Instance.SpawnGameObject(TypeEffect.EffectEnemy.ToString(), this.transform.position);
        effect.localScale = Vector2.one;
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
