using UnityEngine;

public abstract class BaseCoin : BaseMonoBehaviour
{
    [SerializeField] private int _price = 2;

    public int _Price
    {
        get { return _price; }
    }
}
