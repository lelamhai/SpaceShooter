using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpUI : BaseMonoBehaviour
{
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        NextLevel();
    }

    private void NextLevel()
    {
        GameManager.Instance.SetGameState(GameStates.ResetGame);
    }

    protected override void SetDefaultValue()
    {}
}
