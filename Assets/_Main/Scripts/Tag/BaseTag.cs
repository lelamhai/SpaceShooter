using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
    Screen,
    Friend,
    Enemy
}

public abstract class BaseTag : BaseMonoBehaviour
{
    [SerializeField] protected Tag _tagGameObject = Tag.Friend;

    public Tag GetTagGameObject()
    {
        return _tagGameObject;
    }
}
