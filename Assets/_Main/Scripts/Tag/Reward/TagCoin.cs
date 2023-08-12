using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagCoin : BaseTag
{
    protected override void SetDefaultValue()
    {
        _tagGameObject = TypeTag.Coin;
    }
}
