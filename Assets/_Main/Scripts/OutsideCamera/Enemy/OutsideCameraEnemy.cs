public class OutsideCameraEnemy : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectHolders(this.transform);
    }
}
