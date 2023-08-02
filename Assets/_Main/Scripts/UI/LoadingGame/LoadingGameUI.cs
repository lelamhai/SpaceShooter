using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingGameUI : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.SetGameState(GameStates.StopGame);
    }
}
