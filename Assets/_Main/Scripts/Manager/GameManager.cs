using UnityEngine;
using UnityEngine.Events;

public enum GameStates
{
    None,
    Initialize,
    StartGame,
    SetupLevel,
    GamePlay,
    ResetGame,
    FinishLevel,
    NextLevelUp,
    FinishGame,
    LeaveGame,
    LoadingGame,
    StopGame,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStates _currentGameStage = GameStates.None;
    public UnityAction _Initialize, _StartGame, _SetupLevel, _GameOver, _RestartGame, _NextLevelUp, _FinishLevel,  _FinishGame, _LeaveGame, _LoadingGame, _StopGame;

    private void UpdateGameStates()
    {
        switch (_currentGameStage)
        {
            case GameStates.Initialize:
                _Initialize?.Invoke();
                break;

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
                _RestartGame?.Invoke();
                break;

            case GameStates.LoadingGame:
                _LoadingGame?.Invoke();
                break;

            case GameStates.StopGame:
                _StopGame?.Invoke();
                break;

            case GameStates.LeaveGame:
                _LeaveGame?.Invoke();
                break;
        }
    }

    public void SetGameState(GameStates state)
    {
        _currentGameStage = state;
        UpdateGameStates();
    }

    protected override void SetDefaultValue()
    {}
}
