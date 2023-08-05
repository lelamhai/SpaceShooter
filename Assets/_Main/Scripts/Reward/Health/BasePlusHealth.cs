using UnityEngine;

public abstract class BasePlusHealth : BaseMonoBehaviour
{
    [SerializeField] private int _health = 1;

    public int _Health
    {
        get { return _health; }
    }
}
