public class ShootEnemy : BaseAttack
{
    protected override void SpawnBullet()
    {
        SpawnBulletEnemy.Instance.SpawnGameObject(TypeBulletEnemy.RedBulletEnemy.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {
        _timeShooting = 1f;
    }
}
