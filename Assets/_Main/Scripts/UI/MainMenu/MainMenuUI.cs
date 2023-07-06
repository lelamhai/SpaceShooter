using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void ButtonStartGame()
    {
        UIManager.Instance.SetPanelStage(TypePanelUI.GamePlay, this.gameObject);
        GameManager.Instance.SetStage(GameStates.StartGame);
    }

    public void ButtonToturial()
    {
        UIManager.Instance.SetPanelStage(TypePanelUI.ToturialGame, null);
    }

    public void ButtonSetting()
    {
        UIManager.Instance.SetPanelStage(TypePanelUI.SettingGame, null);
    }

    public void ButtonQuit()
    {
        UIManager.Instance.SetPanelStage(TypePanelUI.QuitGame, null);
    }
}
