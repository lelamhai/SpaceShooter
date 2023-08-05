using UnityEngine;

public abstract class BaseHealth : BaseMonoBehaviour
{
    [SerializeField] protected int _maxHealth = 1;
    [SerializeField] protected int _currentHealth = 1;
    [SerializeField] protected BaseSoundEffect _baseSoundEffect;
    [SerializeField] protected SpriteRenderer _model;

    protected virtual void OnEnable()
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
        if (amount <= 0) return;
        HitGameObject();
    }

    public void PlusHealth(int amount)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth += amount;
            PlusHealthGameObject();
        } 
    }

    protected virtual void PlusHealthGameObject()
    {}

    protected virtual void DeadGameObject()
    {
        this.gameObject.SetActive(false);
        if (_baseSoundEffect == null) return;
        _baseSoundEffect.PlaySoundDead();
    }

    protected virtual void HitGameObject()
    {
        if (_baseSoundEffect == null) return;
        _baseSoundEffect.PlaySoundHit();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSoundEffect();
        LoadModel();
    }

    private void LoadSoundEffect()
    {
        _baseSoundEffect = this.GetComponent<BaseSoundEffect>();
    }

    private void LoadModel()
    {
        _model = this.GetComponent<SpriteRenderer>();
    }
}
