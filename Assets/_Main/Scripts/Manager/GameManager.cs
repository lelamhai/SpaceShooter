using UnityEngine;
using UnityEngine.Events;

public enum GameStates
{
    None,
    StartGame,
    SetupLevel,
    GamePlay,
    ResetGame,
    FinishLevel,
    NextLevelUp,
    FinishGame,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStates _currentStage = GameStates.None;
    public UnityAction _StartGame, _SetupLevel, _GameOver, _ResetGame, _FinishLevel, _NextLevelUp, _FinishGame;

    private void UpdateGameStates()
    {
        switch (_currentStage)
        {
            case GameStates.StartGame:
                _StartGame?.Invoke();
                break;

            case GameStates.SetupLevel:
                _SetupLevel?.Invoke();
                break;

            case GameStates.GamePlay:

                break;

            case GameStates.GameOver:
                _GameOver?.Invoke();
                break;

            case GameStates.FinishLevel:
                _FinishLevel?.Invoke();
                break;

            case GameStates.NextLevelUp:
                _NextLevelUp?.Invoke();
                break;

            case GameStates.FinishGame:
                _FinishGame?.Invoke();
                break;

            case GameStates.ResetGame:
                _ResetGame?.Invoke();
                break;
        }
    }

    public void SetStage(GameStates state)
    {
        _currentStage = state;
        UpdateGameStates();
    }

    protected override void SetDefaultValue()
    { }
}
