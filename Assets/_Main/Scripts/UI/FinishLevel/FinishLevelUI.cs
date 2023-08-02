using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelUI : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.SetGameState(GameStates.StopGame);
    }
}
