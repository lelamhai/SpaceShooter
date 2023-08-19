public class OutsideCameraCloud : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectHolders(this.transform);
    }
}
