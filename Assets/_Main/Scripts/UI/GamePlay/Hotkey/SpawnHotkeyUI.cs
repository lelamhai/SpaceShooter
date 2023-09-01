using UnityEngine;

public class SpawnHotkeyUI : SingletonSpawn<SpawnHotkeyUI>, IDataPersistence
{
    [Header("Spawn UI")]
    [SerializeField] protected Transform _slot;

    private void OnEnable()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }

    public void LoadData(GameData data)
    {
        if(data.Inventory.Count == 0)
        {
            LoadInitializeHotkey();
        } else
        {
            LoadHotkey(data);
        }
    }

    private void LoadInitializeHotkey()
    {
        for (int i = 0; i < 4; i++)
        {
            Transform slot = SpawnGameObject(_slot);
            slot.SetParent(_baseHolders.transform);
        }
    }

    private void LoadHotkey(GameData data)
    {
        for (int i = 0; i < 4; i++)
        {
            Transform slot = SpawnGameObject(_slot);
            for (int j = 0; j < data.Inventory.Count; j++)
            {
                //if (data.Inventory[j].Position == i)
                //{
                //    TypeItem type = data.Inventory[j].TypeItem;
                //    Transform itemPrefab = FindInPrefabs(type.ToString());
                //    Transform item = SpawnGameObject(itemPrefab);
                //    SetActive(item, true); 
                //    item.SetParent(slot);
                //}
            }
            slot.SetParent(_baseHolders.transform);
        }
    }

    public void SaveData(GameData data)
    {
    
    }

    protected override void SetDefaultValue()
    {}
}