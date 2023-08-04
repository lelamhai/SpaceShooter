using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagReward : BaseTag
{
    protected override void SetDefaultValue()
    {
        _tagGameObject = Tag.Reward;
    }
}
