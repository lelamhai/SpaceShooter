public class OutsideCameraPlanet : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
