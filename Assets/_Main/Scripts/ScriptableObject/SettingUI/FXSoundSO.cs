using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FXSoundSO", menuName = "ScriptableObject/Setting/FX Sound", order = 0)]
public class FXSoundSO : ScriptableObject
{
    [Range(0, 1f)]
    public float Volume;
}
