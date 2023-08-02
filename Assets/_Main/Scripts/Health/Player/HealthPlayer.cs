using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : BaseHealth
{
    protected override void OnEnable()
    {
        base.OnEnable();
        _model.color = Color.white;
        UIManager.Instance.HealthPlayer(_currentHealth, _maxHealth);
    }

    protected override void DeadGameObject()
    {
        GameManager.Instance.SetGameState(GameStates.GameOver);
        base.DeadGameObject();
        var effect = SpawnEffect.Instance.SpawnGameObject(TypeEffect.EffectEnemy.ToString(), this.transform.position);
        effect.localScale = Vector2.one / 2;       
    }

    protected override void HitGameObject()
    {
        base.HitGameObject();
        StartCoroutine(IEHitGameObject());
        UIManager.Instance.HealthPlayer(_currentHealth, _maxHealth);
    }

    private IEnumerator IEHitGameObject()
    {
        _model.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        _model.color = Color.white;
    }

    protected override void SetDefaultValue()
    {
        _maxHealth = 100;
    }
}
