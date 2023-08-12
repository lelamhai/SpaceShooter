using System;
using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseTag _tag = null;
    [SerializeField] protected BaseDamage _baseDamage = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TypeTag target = collision.gameObject.GetComponent<BaseTag>()._TagGameObject;
        TypeTag current = this.gameObject.GetComponent<BaseTag>()._TagGameObject;

        if ((target == TypeTag.Reward || target == TypeTag.Coin) && current == TypeTag.Enemy) return;
        if (target == current) return;

        ReceiveDamage(collision);

        if(target == TypeTag.Reward)
        {
            ReceiveReward(collision);
        }

        if(target == TypeTag.Coin)
        {
            ReceiveCoin(collision);
        }
    }

    private void ReceiveDamage(Collision2D collision)
    {
        BaseHealth receiveHealthTarget = collision.transform.GetComponent<BaseHealth>();
        if (receiveHealthTarget == null) return;
        receiveHealthTarget.TakeDamage(_baseDamage._Damage);
    }

    protected virtual void ReceiveReward(Collision2D collision)
    {}

    protected virtual void ReceiveCoin(Collision2D collision)
    {}

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadScript();
    }

    private void LoadScript()
    {
        _baseDamage = this.GetComponent<BaseDamage>();
        _tag = this.GetComponent<BaseTag>();
    }
}
