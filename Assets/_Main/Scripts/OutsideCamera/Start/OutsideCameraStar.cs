public class OutsideCameraStar : BaseOutsideCamera
{
    protected override void OutsideCamera()
    {
        SpawnStar.Instance.AddGameObjectHolders(this.transform);
    }
}
