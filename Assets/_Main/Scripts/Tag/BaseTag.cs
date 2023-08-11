using UnityEngine;

public enum TypeTag
{
    Screen,
    Friend,
    Enemy,
    Reward,
    Inventory
}

public abstract class BaseTag : BaseMonoBehaviour
{
    [SerializeField] protected TypeTag _tagGameObject = TypeTag.Friend;
    public TypeTag _TagGameObject
    {
        get { return _tagGameObject; }
    }
}
