using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInsideCamera : BaseMonoBehaviour
{
    [SerializeField] private PolygonCollider2D _polygonCollider2D;
    [SerializeField] private BaseAttack _baseAttack;

    private void OnEnable()
    {
        _polygonCollider2D.isTrigger = true;
    }

    public void CollisionEnter2D(BaseInsideCamera baseInsideCamera)
    {
        InsideCamera();
        SetIsTrigger();
    }

    protected void InsideCamera()
    {
        _baseAttack._CanShoot = true;
    }

    private void SetIsTrigger()
    {
        _polygonCollider2D.isTrigger = false;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPolygonCollider();
        LoadBaseAttack();
    }

    private void LoadPolygonCollider()
    {
        _polygonCollider2D = this.GetComponent<PolygonCollider2D>();
    }

    private void LoadBaseAttack()
    {
        _baseAttack = this.GetComponent<BaseAttack>();
    }
}
