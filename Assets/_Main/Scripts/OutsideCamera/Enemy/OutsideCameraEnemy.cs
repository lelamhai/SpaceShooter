public class OutsideCameraEnemy : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnGameObject.Instance.AddGameObjectPool(this.transform);
    }
}
