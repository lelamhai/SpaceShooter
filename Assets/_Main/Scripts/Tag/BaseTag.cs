using UnityEngine;

public enum Tag
{
    Screen,
    Friend,
    Enemy,
    Reward
}

public abstract class BaseTag : BaseMonoBehaviour
{
    [SerializeField] protected Tag _tagGameObject = Tag.Friend;
    public Tag _TagGameObject
    {
        get { return _tagGameObject; }
    }
}
