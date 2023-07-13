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
        GameManager.Instance._StartGame += LoadLevel;
        GameManager.Instance._FinishLevel += LevelUp;
        GameManager.Instance._NextLevelUp += LoadLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= LoadLevel;
        GameManager.Instance._FinishLevel -= LevelUp;
        GameManager.Instance._NextLevelUp -= LoadLevel;
    }

    private void LevelUp()
    {
        _level++;
        Debug.Log("_level: " + _level);
        if (_level < _listAllLevel.Count)
        {
            UIManager.Instance.SetPanelStage(TypePanelUI.FinishLevel);
        }
        else
        {
            GameManager.Instance.SetGameStage(GameStates.FinishGame);
            UIManager.Instance.SetPanelStage(TypePanelUI.FinishGame);
        }
    }

    private void LoadLevel()
    {
        if (_currentLevelGameObject != null)
        {
            Destroy(_currentLevelGameObject.gameObject);
        }

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
