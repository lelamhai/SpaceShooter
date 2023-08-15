using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHotkeyUI : BaseSpawnUI, IDataPersistence
{
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
