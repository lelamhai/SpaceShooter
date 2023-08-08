using UnityEngine;

public class InsideCameraEnemy : BaseInsideCamera
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
        _baseAttack._CanShoot = true;
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
