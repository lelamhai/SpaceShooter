using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagNone : BaseTag
{
    protected override void SetDefaultValue()
    {
        _tagGameObject = Tag.None;
    }
}
