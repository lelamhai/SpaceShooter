using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseTag _tag = null;
    [SerializeField] protected BaseDamage _baseDamage = null;
    [SerializeField] protected BaseHealth _baseHealth = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tag target = collision.gameObject.GetComponent<BaseTag>()._TagGameObject;
        Tag current = this.gameObject.GetComponent<BaseTag>()._TagGameObject;

        if (target == Tag.Reward && current == Tag.Enemy) return;
        if (target == current) return;

        ReceiveDamage(collision);
        PlusHealth(collision);
    }

    private void ReceiveDamage(Collision2D collision)
    {
        BaseHealth receiveHealthTarget = collision.transform.GetComponent<BaseHealth>();
        if (receiveHealthTarget == null) return;
        receiveHealthTarget.TakeDamage(_baseDamage._Damage);
    }

    private void PlusHealth(Collision2D collision)
    {
        BasePlusHealth basePlusHealth = collision.transform.GetComponent<BasePlusHealth>();
        if (basePlusHealth == null) return;
        _baseHealth.PlusHealth(basePlusHealth._Health);
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
