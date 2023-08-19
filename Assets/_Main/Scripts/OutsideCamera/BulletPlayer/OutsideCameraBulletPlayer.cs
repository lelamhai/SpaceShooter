public class OutsideCameraBulletPlayer : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnBulletPlayer.Instance.AddGameObjectHolders(this.transform);
    }
}
