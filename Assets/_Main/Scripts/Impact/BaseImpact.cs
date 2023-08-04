using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseDamage _baseDamage = null;
    [SerializeField] protected BaseTag _tag = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tag target = collision.gameObject.GetComponent<BaseTag>()._TagGameObject;
        Tag current = this.gameObject.GetComponent<BaseTag>()._TagGameObject;

        if (target == Tag.Reward && current == Tag.Enemy) return;
        if (target == current) return;
        BaseHealth receiveDamage = collision.transform.GetComponent<BaseHealth>();

        if (receiveDamage == null) return;
        receiveDamage.TakeDamage(_baseDamage._Damage);
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
    }
}
