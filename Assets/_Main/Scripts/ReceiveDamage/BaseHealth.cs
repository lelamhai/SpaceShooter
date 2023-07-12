using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHealth : BaseMonoBehaviour
{
    [SerializeField] protected int _maxHealth = 1;
    [SerializeField] protected int _currentHealth = 1;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public bool TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            return true;
        }
        return false;
    }
}
