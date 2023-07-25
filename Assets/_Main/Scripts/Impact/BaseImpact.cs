using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseImpact : BaseMonoBehaviour
{
    [SerializeField] protected BaseDamage _baseDamage = null;
    [SerializeField] protected BaseTag _tag = null;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("OnTriggerEnter2D: " + collision.name);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tag target = collision.gameObject.GetComponent<BaseTag>().GetTagGameObject();
        if (target == Tag.None) return;

        Tag current = this.gameObject.GetComponent<BaseTag>().GetTagGameObject();
        if (current == Tag.None) return;
       
        if (target == current ) return;
        BaseHealth receiveDamage = collision.transform.GetComponent<BaseHealth>();

        if (receiveDamage == null) return;
        receiveDamage.TakeDamage(_baseDamage.Damage());
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
