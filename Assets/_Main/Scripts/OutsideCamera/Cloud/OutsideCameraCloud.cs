public class OutsideCameraCloud : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
