using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : BaseMonoBehaviour
{
    [SerializeField] protected int _maxHealth = 1;
    [SerializeField] protected int _currentHealth = 1;
    [SerializeField] protected BaseSoundEffect _baseSoundEffect;
    [SerializeField] protected SpriteRenderer _model;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth < 1)
        {
            DeadGameObject();
            return;
        }
        HitGameObject();
    }

    protected virtual void DeadGameObject()
    {
        this.gameObject.SetActive(false);
        _baseSoundEffect.PlaySoundDead();
    }

    protected virtual void HitGameObject()
    {
        _baseSoundEffect.PlaySoundHit();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        _baseSoundEffect = this.GetComponent<BaseSoundEffect>();
        _model = this.GetComponent<SpriteRenderer>();
    }
}
