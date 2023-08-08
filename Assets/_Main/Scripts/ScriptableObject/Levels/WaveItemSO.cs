using UnityEngine;

[CreateAssetMenu(fileName = "WaveItem", menuName = "ScriptableObject/Waves/Item", order = 0)]
public class WaveItemSO : ScriptableObject
{
    public TypeGameObject _typeGameObject;
    public float _delay;
    public int _numberGameObject;
}
