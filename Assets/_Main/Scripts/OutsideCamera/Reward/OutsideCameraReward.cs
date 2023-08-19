public class OutsideCameraReward : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnReward.Instance.AddGameObjectHolders(this.transform);
    }
}
