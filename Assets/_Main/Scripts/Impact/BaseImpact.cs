using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseDamage _baseDamage = null;
    [SerializeField] protected BaseTag _tag = null;
    [SerializeField] protected BaseHealth _baseHealth = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tag target = collision.gameObject.GetComponent<BaseTag>()._TagGameObject;
        Tag current = this.gameObject.GetComponent<BaseTag>()._TagGameObject;

        if (target == Tag.Reward && current == Tag.Enemy) return;
        if (target == current) return;

        BaseHealth receiveHealthTarget = collision.transform.GetComponent<BaseHealth>();
        if (receiveHealthTarget == null) return;
        receiveHealthTarget.TakeDamage(_baseDamage._Damage);

        BasePlusHealth basePlusHealthTarget = collision.transform.GetComponent<BasePlusHealth>();
        if (basePlusHealthTarget == null) return;

        if (_baseHealth == null) return;
        _baseHealth.PlusHealth(basePlusHealthTarget._Health);
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
        _baseHealth = this.GetComponent<BaseHealth>();
        _baseDamage = this.GetComponent<BaseDamage>();
        _tag = this.GetComponent<BaseTag>();
    }
}
