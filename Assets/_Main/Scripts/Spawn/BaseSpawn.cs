using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawn : BaseMonoBehaviour
{
    [Header("Base Spawn")]
    [SerializeField] protected BasePrefabs _basePrefabs = null;
    [SerializeField] protected BaseHolders _baseHolders = null;
    [SerializeField] protected Transform _point = null;

    public Transform SpawnGameObject(string name, Vector3 point)
    {
        Transform gameObject = null;
        if (_baseHolders.CountPool(name) > 0)
        {
            gameObject = _baseHolders.UndoGameObject(name);
            if (gameObject == null) return null;
            SetUndoGameObject(gameObject, name, point);
            RemoveGameObjectPool(gameObject);
        } else
        {
            gameObject = _basePrefabs.CloneGameObject(name);
            if (gameObject == null) return null;
            SetUndoGameObject(gameObject, name, point);
        }

        return gameObject;
    }

    private void SetUndoGameObject(Transform gameObject, string name, Vector3 point)
    {
        gameObject.SetPositionAndRotation(point, Quaternion.identity);
        gameObject.gameObject.SetActive(true);
        gameObject.name = name;
        gameObject.SetParent(_baseHolders.transform);
    }

    protected override void LoadComponent()
    {
        Transform prefab = transform.Find("Prefabs");
        _basePrefabs = prefab.GetComponent<BasePrefabs>();

        Transform holder = transform.Find("Holders");
        _baseHolders = holder.GetComponent<BaseHolders>();

        _point = transform.Find("Point");
    }

    public void AddGameObjectPool(Transform gameobject)
    {
        _baseHolders.AddObjectPool(gameobject);
    }

    public void RemoveGameObjectPool(Transform gameobject)
    {
        _baseHolders.RemoveObjectPool(gameobject);
    }


    public Vector2 RandomPoint(float x = 0)
    {
        var posX = Random.Range(-x, x);
        var posY = _point.position.y;
        var posZ = 0;

        return new Vector3(posX, posY, posZ);
    }
}
