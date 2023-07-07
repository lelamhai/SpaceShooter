using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGSoundSO", menuName = "ScriptableObject/Setting/BG Sound", order = 0)]
public class BGSoundSO : ScriptableObject
{
    [Range(0, 1f)]
    public float Volume;
}
