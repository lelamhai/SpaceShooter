using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHolders : BaseMonoBehaviour
{
    [Header("Base Holders")]
    [SerializeField] protected List<Transform> _listPoolObject = new List<Transform>();

    public List<Transform> _ListPoolObject
    {
        get => _listPoolObject;
    }

    public void AddObjectPool(Transform gameObject)
    {
        _listPoolObject.Add(gameObject);
    }

    public void RemoveObjectPool(Transform gameObject)
    {
        foreach (Transform item in _listPoolObject)
        {
            if (gameObject == item)
            {
                _listPoolObject.Remove(item);
                return;
            }
        }
    }

    public Transform FindGameObject(string name)
    {
        foreach (var item in _listPoolObject)
        {
            if (item.name.Equals(name))
            {
                return item;
            }
        }
        return null;
    }

    public void DisableAllGameObject()
    {
        _listPoolObject.Clear();
        Transform parent = this.transform;
        foreach (Transform item in parent)
        {
            AddObjectPool(item);
            item.gameObject.SetActive(false);
        }
    }
}