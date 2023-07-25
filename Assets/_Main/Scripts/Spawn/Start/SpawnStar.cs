using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeStar
{
    BlueStar,
    WhiteStar
}

public class SpawnStar : SingletonSpawn<SpawnStar>
{
    [SerializeField] private TypeStar _currentTypeStar = TypeStar.WhiteStar;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private bool _isDelay = true;
    [SerializeField] private float _durationSpawn = 1f;
   
    private void Update()
    {
        if (!_canSpawn) return;
        if (!_isDelay) return;
        StartCoroutine(IESpawn());
    }

    private IEnumerator IESpawn()
    {
        _isDelay = false;
        SpawnGameObject(_currentTypeStar.ToString(), RandomPoint(8.88889f));
        yield return new WaitForSeconds(_durationSpawn);
        _isDelay = true;
    }

    protected override void SetDefaultValue()
    {}
}
