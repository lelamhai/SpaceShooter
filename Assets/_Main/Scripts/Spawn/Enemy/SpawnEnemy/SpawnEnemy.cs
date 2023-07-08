using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEnemy
{
    Enemy
}

public class SpawnEnemy : SingletonSpawn<SpawnEnemy>
{
    [SerializeField] private TypeEnemy _currentTypeEnemy = TypeEnemy.Enemy;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private bool _isDelay = true;
    [SerializeField] private float _durationSpawn = 1f;
    

    private void Update()
    {
        if (!_canSpawn) return;
        if (!_isDelay) return;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _isDelay = false;
        SpawnGameObject(_currentTypeEnemy.ToString(), _point.position);
        yield return new WaitForSeconds(_durationSpawn);
        _isDelay = true;
    }


    protected override void SetDefaultValue()
    {}
}
