using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.SetGameState(GameStates.StopGame);
    }
}