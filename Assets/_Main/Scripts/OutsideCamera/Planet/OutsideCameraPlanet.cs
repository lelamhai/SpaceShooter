public class OutsideCameraPlanet : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectHolders(this.transform);
    }
}
