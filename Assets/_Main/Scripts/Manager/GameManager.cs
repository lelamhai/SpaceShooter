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
    EndLevel,
    FinishLevel,
    LevelUp,
    NextLevel,
    FinishGame,
    LoadingGame,
    StopGame,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameStates _currentGameStage = GameStates.None;
    public UnityAction _Initialize, _StartGame, _SetupLevel, _GameOver, _RestartGame, _LevelUp, _EndLevel, _FinishLevel, _NextLevel,  _FinishGame, _LoadingGame, _StopGame;
    public UnityAction<int> _SelectLevel;
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

            case GameStates.EndLevel:
                _EndLevel?.Invoke();
                break;

            case GameStates.FinishLevel:
                _FinishLevel?.Invoke();
                break;

            case GameStates.LevelUp:
                _LevelUp?.Invoke();
                break;

            case GameStates.NextLevel:
                _NextLevel?.Invoke();
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
        }
    }

    public void SetGameState(GameStates state)
    {
        _currentGameStage = state;
        UpdateGameStates();
    }

    public void SelectLevel(int level)
    {
        _SelectLevel?.Invoke(level);
    }

    protected override void SetDefaultValue()
    {}
}
