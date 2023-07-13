using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public void ButtonNextLevel()
    {
        GameManager.Instance.SetGameStage(GameStates.NextLevelUp);
        UIManager.Instance.SetPanelStage(TypePanelUI.GamePlay, this.gameObject);
    }
}
