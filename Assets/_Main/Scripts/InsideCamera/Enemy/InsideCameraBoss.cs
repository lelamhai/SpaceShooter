using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCameraBoss : BaseInsideCamera
{
    [SerializeField] private PolygonCollider2D _polygonCollider;
    [SerializeField] private BaseAttack _baseAttack;

    private void OnEnable()
    {
        _polygonCollider.isTrigger = true;
        _baseAttack._CanShoot = false;
    }

    protected override void InsideCamera()
    {
        _polygonCollider.isTrigger = false;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPolygon();
        LoadBaseAttack();
    }

    private void LoadPolygon()
    {
        _polygonCollider = this.GetComponent<PolygonCollider2D>();
    }

    private void LoadBaseAttack()
    {
        _baseAttack = this.GetComponent<BaseAttack>();
    }
}
