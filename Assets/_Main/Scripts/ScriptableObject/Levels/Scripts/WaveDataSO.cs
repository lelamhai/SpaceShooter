using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObject/Waves/Wave", order = 0)]
public class WaveDataSO : ScriptableObject
{
    public List<WaveItemSO> _lisWave;
    public float _timerBetweenWave;
    public float _duration;
}
