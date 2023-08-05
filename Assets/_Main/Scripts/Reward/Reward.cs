using System.Collections.Generic;
using UnityEngine;

public class Reward : BaseMonoBehaviour
{
    [SerializeField] private List<ItemReward> _listReward = new List<ItemReward>();
    [SerializeField] private TypeReward _currentTypeReward = TypeReward.None;

    public TypeReward _CurrentTypeReward
    {
        get { return _currentTypeReward; }
    }

    private void OnEnable()
    {
        if(_listReward.Count == 0)
        {
            Debug.Log("List reward empty");
            return;
        }
        _currentTypeReward = GetRandomReward();
    }

    protected TypeReward GetRandomReward()
    {
        float totalWeight = 0;

        foreach (ItemReward p in _listReward)
        {
            totalWeight += p._weight;
        }
        float value = Random.value * totalWeight;

        float sumWeight = 0;
        foreach (ItemReward p in _listReward)
        {
            sumWeight += p._weight;
            if (sumWeight >= value)
            {
                return p._typeReward;
            }
        }
        return TypeReward.None;
    }

    protected override void SetDefaultValue()
    {}
}

[System.Serializable]
public struct ItemReward
{
    public TypeReward _typeReward;
    public float _weight;
}