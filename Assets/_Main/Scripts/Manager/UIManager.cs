using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypePanelUI
{
    GamePlay,
    MainMenu,
    ToturialGame,
    SettingGame,
    PauseGame,
    QuitGame
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _gamePlay;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingGame;
    [SerializeField] private GameObject _toturialGame;
    [SerializeField] private GameObject _pauseGame;
    [SerializeField] private GameObject _quitGame;
    [SerializeField] private TypePanelUI _currentUIStage = TypePanelUI.MainMenu;
    public UnityAction<bool> _AutoShootingUI, _Joystick;

    private void Start()
    {
        SetPanelStage(_currentUIStage, null);
        #if UNITY_EDITOR
            Joystick(false);
        #endif

        #if UNITY_IOS
            Debug.Log("iOS");
        #endif

        #if UNITY_STANDALONE_OSX
            Debug.Log("Standalone OSX");
        #endif

        #if UNITY_STANDALONE_WIN
            Joystick(false);
        #endif
    }

    private void UpdatePanelStage(GameObject oldPanel = null)
    {
        switch(_currentUIStage)
        {
            case TypePanelUI.GamePlay:
                _gamePlay.SetActive(true);
                break;

            case TypePanelUI.MainMenu:
                _mainMenu.SetActive(true);
                break;

            case TypePanelUI.SettingGame:
                _settingGame.SetActive(true);
                break;

            case TypePanelUI.ToturialGame:
                _toturialGame.SetActive(true);
                break;

            case TypePanelUI.PauseGame:
                _pauseGame.SetActive(true);
                break;

            case TypePanelUI.QuitGame:
                _quitGame.SetActive(true);
                break;
        }

        if (oldPanel == null) return;
        oldPanel.SetActive(false);
    }

    public void SetPanelStage(TypePanelUI state, GameObject oldPanel = null)
    {
        _currentUIStage = state;
        UpdatePanelStage(oldPanel);
    }

    public void AutoShooting(bool active)
    {
        _AutoShootingUI?.Invoke(active);
    }

    public void Joystick(bool active)
    {
        _Joystick?.Invoke(active);
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAllUI();
    }

    private void LoadAllUI()
    {
        _gamePlay = this.transform.Find("GamePlay").gameObject;
        _gamePlay.SetActive(false);

        _mainMenu = this.transform.Find("MainMenu").gameObject;
        _mainMenu.SetActive(false);

        _toturialGame = this.transform.Find("TutorialGame").gameObject;
        _toturialGame.SetActive(false);

        _settingGame = this.transform.Find("SettingGame").gameObject;
        _settingGame.SetActive(false);

        _pauseGame = this.transform.Find("PauseGame").gameObject;
        _pauseGame.SetActive(false);

        _quitGame = this.transform.Find("QuitGame").gameObject;
        _quitGame.SetActive(false);
    }
}
