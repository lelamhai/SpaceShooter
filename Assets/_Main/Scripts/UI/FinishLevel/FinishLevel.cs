using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public void ButtonNextLevel()
    {
        GameManager.Instance.SetGameState(GameStates.NextLevelUp);
        UIManager.Instance.SetPanelState(TypePanelUI.GamePlay, PanelState.Show);
    }
}
