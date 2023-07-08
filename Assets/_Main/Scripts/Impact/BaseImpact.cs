using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour, ITypeCharactor
{
    [SerializeField] protected BaseDamage _baseDamage = null;
    [SerializeField] protected TypeCharactorGame _typeCharactorGame = TypeCharactorGame.Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TypeCharactorGame target = collision.gameObject.GetComponent<ITypeCharactor>().TypeCharactor();
        TypeCharactorGame current = this.gameObject.GetComponent<ITypeCharactor>().TypeCharactor();

        if (target == current) return;
        BaseReceiveDamage receiveDamage = collision.transform.GetComponent<BaseReceiveDamage>();
        if (receiveDamage == null) return;
        receiveDamage.TakeDamage(_baseDamage.Damage());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TypeCharactorGame target = collision.gameObject.GetComponent<ITypeCharactor>().TypeCharactor();
        TypeCharactorGame current = this.gameObject.GetComponent<ITypeCharactor>().TypeCharactor();

        if (target == current) return;
        BaseReceiveDamage receiveDamage = collision.transform.GetComponent<BaseReceiveDamage>();
        if (receiveDamage == null) return;
        receiveDamage.TakeDamage(_baseDamage.Damage());
        HitGameObject(collision);
    }

    protected abstract void HitGameObject(Collision2D collision);

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        _baseDamage = this.GetComponent<BaseDamage>();
    }

    public TypeCharactorGame TypeCharactor()
    {
        return _typeCharactorGame;
    }
}
