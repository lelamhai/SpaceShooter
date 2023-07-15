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
    [SerializeField] private int _level = 0;

    private Transform _currentLevelGameObject = null;

    private void OnEnable()
    {
        GameManager.Instance._StartGame += StartGame;
        GameManager.Instance._StopGame += StopGame;
        GameManager.Instance._FinishLevel += FinishGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= StartGame;
        GameManager.Instance._StopGame -= StopGame;
        GameManager.Instance._FinishLevel -= FinishGame;
    }

    private void StopGame()
    {
        if (_currentLevelGameObject == null) return;
        Destroy(_currentLevelGameObject.gameObject);
    }

    private void FinishGame()
    {
        Debug.Log("FinishGame");
        _level++;
    }

    private void StartGame()
    {
        if (_listAllLevel.Count <= 0)
        {
            Debug.LogError("List level empty");
            return;
        }

        _currentLevelGameObject = Instantiate(_listAllLevel[_level], _parent);
        _currentLevelGameObject.transform.SetParent(_parent);
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
}
