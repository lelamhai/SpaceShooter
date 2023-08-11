using System.Collections;
using UnityEngine;

public class HealthBoss : BaseHealth
{
    [SerializeField] protected RandomReward _reward;

    protected override void OnEnable()
    {
        base.OnEnable();
        SetDefaultColor();
    }

    private void SetDefaultColor()
    {
        _model.color = Color.white;
    }

    protected override void DeadGameObject()
    {
        base.DeadGameObject();
        StateGameGameObject();
        SpawnEffectGameObject();
    }

    private void StateGameGameObject()
    {
        GameManager.Instance.SetGameState(GameStates.LevelUp);
        GameManager.Instance.SetGameState(GameStates.EndLevel);
    }

    private void SpawnEffectGameObject()
    {
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

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadReward();
    }

    private void LoadReward()
    {
        _reward = this.GetComponent<RandomReward>();
    }
}
