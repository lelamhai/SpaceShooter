using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyEnemy : BaseMonoBehaviour
{
    [SerializeField] private PolygonCollider2D _polygonCollider2D;

    private void OnEnable()
    {
        _polygonCollider2D.isTrigger = true;
    }

    private void OnDisable()
    {
        _polygonCollider2D.isTrigger = false;
    }

    protected override void SetDefaultValue()
    { }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPolygonCollider();
    }

    private void LoadPolygonCollider()
    {
        _polygonCollider2D = this.GetComponent<PolygonCollider2D>();
    }
}
