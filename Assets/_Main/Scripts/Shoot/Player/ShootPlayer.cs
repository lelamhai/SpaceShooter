public class ShootPlayer : BaseAttack
{
    private TypeBulletPlayer _currentBullet;

    private void Awake()
    {
        _currentBullet = SpawnBulletPlayer.Instance._CurrentBullet;
    }

    private void OnEnable()
    {
        GameManager.Instance._StartGame += StartGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame += StartGame;
    }

    private void StartGame()
    {
        _canShoot = true;
    }

    protected override void SpawnBullet()
    {
        SpawnBulletPlayer.Instance.SpawnGameObject(_currentBullet.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {
        _canShoot = false;
        _timeShooting = 0.5f;
    }
}
