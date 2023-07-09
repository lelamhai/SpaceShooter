using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveItem", menuName = "ScriptableObject/Waves/Item", order = 0)]
public class WaveItemSO : ScriptableObject
{
    public TypeEnemy _typeEnemy;
    public float _delay;
    public int _numberEnemy;
}
