public class OutsideCameraReward : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnReward.Instance.AddGameObjectPool(this.transform);
    }
}
