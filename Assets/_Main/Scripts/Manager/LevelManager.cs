using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>, IDataPersistence
{
    [Header("Finish Game")]
    [SerializeField] private bool _finishGame = false;
    public bool _FinishGame
    {
        get { return _finishGame; }
    }

    [Header("Load level in GamePlay")]
    [SerializeField] private Transform _parent;

    [Header("All level in Game")]
    [SerializeField] private List<Transform> _listAllLevel = new List<Transform>();
    [SerializeField] private int _currentLevel = 0;
    private int _level = 0;

    public int _CountLevel
    {
        get { return _listAllLevel.Count; }
    }

    public int _CurrentLevel
    {
        get { return _currentLevel; }
    }

    private Transform _currentLevelGameObject = null;

    private void OnEnable()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);

        GameManager.Instance._StartGame += StartGame;
        GameManager.Instance._StopGame += StopGame;
        GameManager.Instance._LevelUp += LevelUp;
        GameManager.Instance._NextLevel += NextLevel;
        GameManager.Instance._SelectLevel += SelectLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= StartGame;
        GameManager.Instance._StopGame -= StopGame;
        GameManager.Instance._LevelUp -= LevelUp;
        GameManager.Instance._NextLevel -= NextLevel;
        GameManager.Instance._SelectLevel -= SelectLevel;
    }

    private void StopGame()
    {
        if (_currentLevelGameObject == null) return;
        Destroy(_currentLevelGameObject.gameObject);
    }

    private void LevelUp()
    {
        if (_currentLevel > _level) return;
        _level++;
        _currentLevel = _level;
    }

    private void NextLevel()
    {
        UIManager.Instance.SetPanelState(TypePanelUI.FinishLevel, PanelState.Show);

        if(_currentLevel >= _CountLevel)
        {
            _finishGame = true;
        }
    }

    private void StartGame()
    {
        CheckLevel();
        LoadLevel(_level);
    }

    private void CheckLevel()
    {
        if (_currentLevel >= _CountLevel)
        {
            _currentLevel = _CountLevel - 1;
        }

        _level = _currentLevel;
    }

    private void SelectLevel(int level)
    {
        _level = level;
    }

    private void LoadLevel(int level)
    {
        if (_listAllLevel.Count <= 0)
        {
            Debug.LogError("List level empty");
            return;
        }

        _currentLevelGameObject = Instantiate(_listAllLevel[_level], _parent);
        _currentLevelGameObject.SetParent(_parent);
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
        _currentLevel = data.Level;
    }

    public void SaveData(GameData data)
    {
        data.Level = _currentLevel;
    }
}
