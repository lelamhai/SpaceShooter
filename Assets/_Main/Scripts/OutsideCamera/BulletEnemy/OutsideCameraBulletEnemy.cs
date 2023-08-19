public class OutsideCameraBulletEnemy : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnBulletEnemy.Instance.AddGameObjectHolders(this.transform);
    }
}
