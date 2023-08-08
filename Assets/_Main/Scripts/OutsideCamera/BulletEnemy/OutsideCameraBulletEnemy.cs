public class OutsideCameraBulletEnemy : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnBulletEnemy.Instance.AddGameObjectPool(this.transform);
    }
}
