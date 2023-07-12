using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseDamage _baseDamage = null;
    [SerializeField] protected BaseTag _tag = null;
    [SerializeField] protected BaseSoundEffect _baseSoundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tag target = collision.gameObject.GetComponent<BaseTag>().GetTagGameObject();
        Tag current = this.gameObject.GetComponent<BaseTag>().GetTagGameObject();

        if (target == current) return;
        BaseHealth receiveDamage = collision.transform.GetComponent<BaseHealth>();
        if (receiveDamage == null) return;
        if (receiveDamage.TakeDamage(_baseDamage.Damage()))
        {
            DeadGameObject(collision.transform);
        }
        else
        {
            HitGameObject(collision.transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tag target = collision.gameObject.GetComponent<BaseTag>().GetTagGameObject();
        Tag current = this.gameObject.GetComponent<BaseTag>().GetTagGameObject();

        if (target == current) return;
        BaseHealth receiveDamage = collision.transform.GetComponent<BaseHealth>();
        if (receiveDamage == null) return;
        if (receiveDamage.TakeDamage(_baseDamage.Damage()))
        {
            DeadGameObject(collision.transform);
        }
        else
        {
            HitGameObject(collision.transform);
        }
    }

    protected virtual void DeadGameObject(Transform transform)
    {
        _baseSoundEffect.PlaySoundDead();
    }

    protected virtual void HitGameObject(Transform transform)
    {
        _baseSoundEffect.PlaySoundHit();
    }

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
        _baseSoundEffect = this.GetComponent<BaseSoundEffect>();
    }
}
