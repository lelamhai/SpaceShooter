using System.Collections.Generic;
using UnityEngine;

public class RandomItem : BaseMonoBehaviour
{
    [SerializeField] private List<ItemReward> _listItem = new List<ItemReward>();
    [SerializeField] private TypeItem _currentTypeItem = TypeItem.None;

    public TypeItem _CurrentTypeReward
    {
        get { return _currentTypeItem; }
    }

    private void OnEnable()
    {
        if(_listItem.Count == 0)
        {
            Debug.Log("List reward empty", this.gameObject);
            return;
        }
        _currentTypeItem = GetRandomReward();
    }

    protected TypeItem GetRandomReward()
    {
        float totalWeight = 0;

        foreach (ItemReward p in _listItem)
        {
            totalWeight += p._weight;
        }
        float value = Random.value * totalWeight;

        float sumWeight = 0;
        foreach (ItemReward p in _listItem)
        {
            sumWeight += p._weight;
            if (sumWeight >= value)
            {
                return p._typeItem;
            }
        }
        return TypeItem.None;
    }

    protected override void SetDefaultValue()
    {}
}

[System.Serializable]
public struct ItemReward
{
    public TypeItem _typeItem;
    public float _weight;
}