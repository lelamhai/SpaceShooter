using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingGame : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.SetGameState(GameStates.StopGame);
    }
}
