using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInventoryUI : SingletonSpawn<SpawnInventoryUI>, IDataPersistence
{
    [Header("Spawn UI")]
    [SerializeField] protected Transform _slot;
    [SerializeField] private List<AttributeSlot> _listSlot = new List<AttributeSlot>();
    [SerializeField] private List<AttributeSlot> _inventory;

    private GameData _gameData;

    private void Start()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
        _gameData = DataPersistanceManager.Instance._GameData;
        _inventory = PlayerInventory.Instance._Inventory;
        LoadSlots();
    }

    private void Update()
    {
        UpdateInventoryUI();
    }

    private void LoadSlots()
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

    private void UpdateInventoryUI()
    {
        var slots = _baseHolders.transform;

        for (int i = 0; i < slots.childCount; i++)
        {
            if(_inventory[i].Slot == i)
            {

            }
        }
    }

    private void LoadItem()
    {
        if (_listSlot.Count <= 0) return;


        for (int i = 0; i < 12; i++)
        {
            Transform cloneSlot = SpawnGameObject(_slot);
            Slot slot = cloneSlot.GetComponent<Slot>();

            Transform itemPrefab = FindGameObject(i);
            if (itemPrefab != null)
            {
                slot._AttributeISlot.Slot = i;
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
        //data.Inventory = _listSlot;
    }

    protected override void SetDefaultValue()
    { }
}