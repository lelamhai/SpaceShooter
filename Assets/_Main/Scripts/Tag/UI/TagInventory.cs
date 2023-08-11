using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagInventory : BaseTag
{
    protected override void SetDefaultValue()
    {
        _tagGameObject = TypeTag.Inventory;
    }
}
