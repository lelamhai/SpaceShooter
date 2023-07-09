using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot180 : BaseAttack
{
    [SerializeField] private int _bulletAmount = 3;
    [SerializeField] private float _startAngle = 0, _endAngle = 180f;
    [SerializeField] private float _pointBegin = 30;
    protected override void SpawnBullet()
    {
        float angleStep = (_endAngle - _startAngle) / _bulletAmount;
        float _angle = _pointBegin;
        for (int i = 0; i < _bulletAmount; i++)
        {
            float bulletDirX = this.transform.position.x + Mathf.Sin((_angle * Mathf.PI) / 180);
            float bulletDirY = this.transform.position.y + Mathf.Cos((_angle * Mathf.PI) / 180);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0);
            Vector2 buletDir = (bulletMoveVector - this.transform.position).normalized;

            Transform bullet = SpawnBulletEnemy.Instance.SpawnGameObject(TypeBulletEnemy.RedBulletEnemy.ToString(), _point.position);

            bullet.GetComponent<BaseMove>().SetRotation(buletDir);
            _angle += angleStep;
        }
    }

    protected override void SetDefaultValue()
    {}
}
