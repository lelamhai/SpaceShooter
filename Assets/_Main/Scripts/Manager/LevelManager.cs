using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Load level in GamePlay")]
    [SerializeField] private Transform _parent;

    [Header("All level in Game")]
    [SerializeField] private List<Transform> _listAllLevel = new List<Transform>();
    [SerializeField] private LevelSO _level;

    public int Level
    {
        get
        {
            return _level._Value;
        }
    }

    private Transform _currentLevelGameObject = null;

    private void OnEnable()
    {
        GameManager.Instance._StartGame += StartGame;
        GameManager.Instance._StopGame += StopGame;
        GameManager.Instance._FinishLevel += FinishLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= StartGame;
        GameManager.Instance._StopGame -= StopGame;
        GameManager.Instance._FinishLevel -= FinishLevel;
    }

    private void StopGame()
    {
        if (_currentLevelGameObject == null) return;
        Destroy(_currentLevelGameObject.gameObject);
    }

    private void FinishLevel()
    {
        _level._Value++;

        if(_level._Value < _listAllLevel.Count)
        {
            UIManager.Instance.SetPanelState(TypePanelUI.FinishLevel, PanelState.Show);
        }
        else
        {
            UIManager.Instance.SetPanelState(TypePanelUI.FinishGame, PanelState.Show);
        }
    }

    private void StartGame()
    {
        if (_listAllLevel.Count <= 0)
        {
            Debug.LogError("List level empty");
            return;
        }

        _currentLevelGameObject = Instantiate(_listAllLevel[_level._Value], _parent);
        _currentLevelGameObject.SetParent(_parent);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadParent();
        LoadLevelSO();
    }

    private void LoadParent()
    {
        _parent = GameObject.Find("[ GamePlay ]").transform;
    }

    private void LoadLevelSO()
    {
        string path = "Level/LevelSO";
        this._level = Resources.Load<LevelSO>(path);
    }
}
