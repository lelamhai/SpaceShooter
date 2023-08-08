using UnityEngine;

public enum TypeBulletPlayer
{
    RedBulletPlayer = 0,
    BlueBulletPlayer = 1
}

public class SpawnBulletPlayer : SingletonSpawn<SpawnBulletPlayer>, IDataPersistence
{
    [SerializeField] private TypeBulletPlayer _currentBullet = TypeBulletPlayer.RedBulletPlayer;

    public TypeBulletPlayer _CurrentBullet
    {
        get { return _currentBullet; }
    }

    private void OnEnable()
    {
        GameManager.Instance._StopGame += StopGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StopGame -= StopGame;
    }

    private void StopGame()
    {
        _baseHolders.DisableAllGameObject();
    }

    protected override void SetDefaultValue()
    {}

    public void LoadData(GameData data)
    {
        _currentBullet = data.Player.Bullet;
    }

    public void SaveData(GameData data)
    {
        data.Player.Bullet = _currentBullet ;
    }
}
