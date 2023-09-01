using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInventoryUI : SingletonSpawn<SpawnInventoryUI>, IDataPersistence
{
    [Header("Spawn UI")]
    [SerializeField] protected Transform _slot;
    [SerializeField] private List<AttributeSlot> _listSlot = new List<AttributeSlot>();

    private GameData _gameData;

    private void OnEnable()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
        _gameData = DataPersistanceManager.Instance._GameData;
        LoadInventory();
    }

    private void LoadInventory()
    {
        for (int i = 0; i < 12; i++)
        {
            Transform cloneSlot = SpawnGameObject(_slot);
            SetParent(cloneSlot, _baseHolders.transform);
            _baseHolders.AddObjectPool(cloneSlot);
        }
    }

    public void LoadData(GameData data)
    {}

    private void LoadSlots()
    {
        if (_gameData.Inventory.Count <= 0) return;

        for (int i = 0; i < 12; i++)
        {
            Transform cloneSlot = SpawnGameObject(_slot);
            Slot slot = cloneSlot.GetComponent<Slot>();

            Transform itemPrefab = FindGameObject(i);
            if (itemPrefab != null)
            {
                slot._AttributeISlot.Slot = i;
                //slot._AttributeISlot.Item = i;
                SetActive(itemPrefab, true);
                SetParent(itemPrefab, cloneSlot);
            }

            SetParent(cloneSlot, _baseHolders.transform);
            _baseHolders.AddObjectPool(cloneSlot);
        }
    }

    private Transform FindGameObject(int index)
    {
        if(_gameData.Inventory.Count > index)
        {
            //AttributeItem attribute = _gameData.Inventory[index];
            //return _basePrefabs.FindGameObject(attribute.TypeItem.ToString());
        }
        return null;
    }
    
    public void SaveData(GameData data)
    {
        data.Inventory = _listSlot;
    }

    protected override void SetDefaultValue()
    { }
}