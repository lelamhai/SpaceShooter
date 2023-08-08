public class OutsideCameraBulletPlayer : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnBulletPlayer.Instance.AddGameObjectPool(this.transform);
    }
}
