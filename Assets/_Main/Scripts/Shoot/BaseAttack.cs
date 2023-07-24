using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : BaseMonoBehaviour
{
    [SerializeField] protected bool _canShoot = true;
    [SerializeField] protected bool _isDelay = true;
    [SerializeField] protected float _timeShooting = 2f;
    [SerializeField] protected Transform _point = null;

    public bool _CanShoot
    {
        set { _canShoot = value; }
    }

    private void OnEnable()
    {
        _canShoot = false;
        _isDelay = true;
    }

    private void Update()
    {
        if (!_canShoot) return;
        if (!_isDelay) return;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _isDelay = false;
        SpawnBullet();
        yield return new WaitForSeconds(_timeShooting);
        _isDelay = true;
    }

    protected abstract void SpawnBullet();

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPoint();
    }

    private void LoadPoint()
    {
        _point = this.transform.Find("Point");
    }
}
