using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagEnemy : BaseTag
{
    protected override void SetDefaultValue()
    {
        _tagGameObject = Tag.Enemy;
    }
}
