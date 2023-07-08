using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamagePlayer : BaseReceiveDamage
{
    protected override void DeadGameObject()
    {}

    protected override void SetDefaultValue()
    {
        _maxHealth = 10;
    }
}
