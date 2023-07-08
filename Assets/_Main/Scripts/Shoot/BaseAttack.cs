using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : BaseMonoBehaviour
{
    [SerializeField] protected bool _canShooting = true;
    [SerializeField] protected bool _isDelay = true;
    [SerializeField] protected float _durationDelayShooting = 2f;
    [SerializeField] protected Transform _point = null;

    private void Update()
    {
        if (!_canShooting) return;
        if (!_isDelay) return;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _isDelay = false;
        SpawnBullet();
        yield return new WaitForSeconds(_durationDelayShooting);
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
