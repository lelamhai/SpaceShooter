using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypePlanet
{
    BluePlanet,
    GreenPlanet,
    PinkPlanet,
}

public class SpawnPlanet : BaseSpawn
{
    [SerializeField] private TypePlanet _currentTypePlanet = TypePlanet.BluePlanet;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private bool _isDelay = true;
    [SerializeField] private float _durationSpawn = 1f;
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

    private void Update()
    {
        if (!_canSpawn) return;
        if (!_isDelay) return;
        StartCoroutine(IESpawn());
    }

    private IEnumerator IESpawn()
    {
        _isDelay = false;
        SpawnGameObject(_currentTypePlanet.ToString(), _point.position);
        yield return new WaitForSeconds(_durationSpawn);
        _isDelay = true;
    }

    protected override void SetDefaultValue()
    {
        _canSpawn = false;
    }
}
