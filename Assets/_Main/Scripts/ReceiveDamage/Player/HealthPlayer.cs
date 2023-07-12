using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : BaseHealth
{
    protected override void SetDefaultValue()
    {
        _maxHealth = 10;
    }
}
