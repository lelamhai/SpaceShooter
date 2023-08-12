using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Invetories/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public int _Id;
    public TypeItem _TypeItem;
    public Sprite _Avatar;
    public GameObject _GameObject;
    public int _MaxItem;
    public int _CountItem;
    [TextArea]
    public string description;
}
