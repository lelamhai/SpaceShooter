using UnityEngine;

public class Shoot360 : BaseAttack
{
    [SerializeField] private int _bulletAmount = 10;

    protected override void SpawnBullet()
    {
        float angleStep = 360 / _bulletAmount;
        float _angle = 0;

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
