using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataPersistanceManager : Singleton<DataPersistanceManager>
{
    [Header("File Storage Config")]
    [SerializeField] private string _fileName;
    [SerializeField] private bool _useEncryption;

    [Space]
    [Header("Script IDataPersistence")]
    [SerializeField] protected LevelManager _levelManager;
    [SerializeField] protected SpawnPlayer _spawnPlayer;
    [SerializeField] protected SpawnBulletPlayer _spawnBulletPlayer;

    
    private List<IDataPersistence> _dataPersistenceObjects = new List<IDataPersistence>();
    private GameData _gameData;
    private FileDataHandler _dataHandler;

    private void Awake()
    {
        this._dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _useEncryption);
    }

    private void Start()
    {
        AddDataPersistence();
        LoadGame();
    }

    private void OnEnable()
    {
        GameManager.Instance._LevelUp += LevelUp;
    }

    private void OnDisable()
    {
        GameManager.Instance._LevelUp -= LevelUp;
    }

    private void LevelUp()
    {
        SaveGame();
    }

    private void NewGame()
    {
        this._gameData = new GameData();
    }

    private void LoadGame()
    {
        this._gameData = _dataHandler.Load();

        if (this._gameData == null)
        {
            Debug.Log("No data was found. Initailizing data to defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
    }

    private void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(_gameData);
        }

        _dataHandler.Save(_gameData);
    }

    public void ClearData()
    {
        _dataHandler.Clear();
    }

    protected override void SetDefaultValue()
    {
        _fileName = "GameData.game";
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadScript();
    }

    private void LoadScript()
    {
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        _spawnPlayer = GameObject.Find("SpawnPlayer").GetComponent<SpawnPlayer>();
        _spawnBulletPlayer = GameObject.Find("SpawnBulletPlayer").GetComponent<SpawnBulletPlayer>();
    }

    private void AddDataPersistence()
    {
        _dataPersistenceObjects.Add(_levelManager);
        _dataPersistenceObjects.Add(_spawnPlayer);
        _dataPersistenceObjects.Add(_spawnBulletPlayer);
    }
}