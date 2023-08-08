public class OutsideCameraStar : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnStar.Instance.AddGameObjectPool(this.transform);
    }
}
