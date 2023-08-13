using UnityEngine;

public enum TypePlayer
{
    Player = 0,
}

public class SpawnPlayer : BaseSpawn, IDataPersistence
{
    [Header("Load level in GamePlay")]
    [SerializeField] private Transform _parent;

    [SerializeField] private TypePlayer _currentPlayer = TypePlayer.Player;
    [SerializeField] private Transform _player = null;
    private void OnEnable()
    {
        GameManager.Instance._Initialize += Initialize;
        GameManager.Instance._StopGame += StopGame;

    }

    private void OnDisable()
    {
        GameManager.Instance._Initialize -= Initialize;
        GameManager.Instance._StopGame -= StopGame;
    }

    private void Initialize()
    {
        _player = SpawnGameObjectNone(_currentPlayer.ToString(), _point.position);
        _player.gameObject.SetActive(true);
        _player.name = _currentPlayer.ToString();
        _player.SetParent(_parent);
    }

    private void StopGame()
    {
        if (_player != null)
        {
            Destroy(_player.gameObject);
        }
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadParent();
    }

    private void LoadParent()
    {
        _parent = GameObject.Find("[ GamePlay ]").transform;
    }

    public void LoadData(GameData data)
    {
        _currentPlayer = data.Player.Plane;
    }

    public void SaveData(GameData data)
    {
        data.Player.Plane = _currentPlayer;
    }
}
