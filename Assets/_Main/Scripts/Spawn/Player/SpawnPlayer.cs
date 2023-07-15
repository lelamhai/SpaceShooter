using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypePlayer
{
    Player
}

public class SpawnPlayer : BaseSpawn
{
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
}
