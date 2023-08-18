using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHotkeyUI : BaseSpawnUI, IDataPersistence
{
    private void OnEnable()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }

    public void LoadData(GameData data)
    {
        foreach (var item in data.Inventories)
        {
            SpawnUI(item.TypeItem);
        }
    }

    public void SaveData(GameData data)
    {}
}
