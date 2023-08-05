using System.Collections;
using UnityEngine;

public class HealthEnemy : BaseHealth
{
    [SerializeField] protected Reward _reward;


    protected override void OnEnable()
    {
        base.OnEnable();
        _model.color = Color.white;
    }

    protected override void DeadGameObject()
    {
        base.DeadGameObject();
        SpawnRewardGameObject();
        SpawnEffectGameObject();
    }

    private void SpawnEffectGameObject()
    {
        var effect = SpawnEffect.Instance.SpawnGameObject(TypeEffect.EffectEnemy.ToString(), this.transform.position);
        effect.localScale = Vector2.one / 2;
    }

    private void SpawnRewardGameObject()
    {
        if (_reward._CurrentTypeReward == TypeReward.None) return;
        SpawnReward.Instance.SpawnGameObject(_reward._CurrentTypeReward.ToString(), this.transform.position);
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

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadReward();
    }

    private void LoadReward()
    {
        _reward = this.GetComponent<Reward>();
    }

    protected override void SetDefaultValue()
    {}
}
