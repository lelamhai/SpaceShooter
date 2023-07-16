using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.SetGameState(GameStates.StopGame);
    }
}
