using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnUI : BaseMonoBehaviour
{
    [SerializeField] private BasePrefabsUI _prefabs;
    [SerializeField] private BaseHoldersUI _holders;

    protected void SpawnUI(TypeItem typeItem)
    {
        Debug.Log("SpawnUI");

        Transform slot = Instantiate(_prefabs._Slot);

        BaseItem baseItem = _prefabs.FindItem(typeItem);
        Transform item = CloneItemUI(baseItem);
        item.gameObject.SetActive(true);

        item.SetParent(slot);

        slot.transform.SetParent(_holders.transform);
    }

    private Transform CloneItemUI(BaseItem item)
    {
        return Instantiate(item.transform);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadScript();
    }

    private void LoadScript()
    {
        _holders = transform.Find("Holders").GetComponent<BaseHoldersUI>();
        _prefabs = transform.Find("Prefabs").GetComponent<BasePrefabsUI>();
    }
}
