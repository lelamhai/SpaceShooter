using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePrefabs : BaseMonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] private List<string> _keys = new List<string>();
    [SerializeField] private List<Transform> _values = new List<Transform>();
    private Dictionary<string, Transform> _listPrefabs = new Dictionary<string, Transform>();

    public Dictionary<string, Transform> _ListPrefabs
    {
        get => _listPrefabs;
    }

    public Transform FindGameObject(string name)
    {
        if (_listPrefabs.ContainsKey(name))
        {
            return _listPrefabs[name];
        }
        return null;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        AddPrefabs();
    }

    protected virtual void AddPrefabs()
    {
        Transform prefabGameObject = this.transform;
        foreach (Transform item in prefabGameObject)
        {
            _listPrefabs.Add(item.name, item);
            item.gameObject.SetActive(false);
        }
    }

    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach (var kvp in _listPrefabs)
        {
            _keys.Add(kvp.Key);
            _values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        _listPrefabs = new Dictionary<string, Transform>();

        for (int i = 0; i != Math.Min(_keys.Count, _values.Count); i++)
            _listPrefabs.Add(_keys[i], _values[i]);
    }
}