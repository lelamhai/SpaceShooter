using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDamage : BaseMonoBehaviour
{
    [SerializeField] protected int _damage = 1;

    public int _Damage
    {
        get { return _damage; }
    }
}
