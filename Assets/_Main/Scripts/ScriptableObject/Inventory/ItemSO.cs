using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Invetories/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    public int _Id;
    public TypeItem _TypeItem;
    public Sprite _Avatar;
    public int _MaxItem;
    public int _CountItem;
    [TextArea]
    public string _Description;

    public ItemSO()
    {
        this._Id = 1;
        this._TypeItem = TypeItem.None;
        this._Avatar = null;
        this._MaxItem = 99;
        this._CountItem = 1;
        this._Description = string.Empty;
    }
}
