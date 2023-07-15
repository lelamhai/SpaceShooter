using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public enum TypePanelUI
{
    GamePlay,
    MainMenu,
    TutorialGame,
    SettingGame,
    FinishLevel,
    FinishGame,
    PauseGame,
    GameOver,
    LoadingGame,
    QuitGame
}

public enum  PanelState
{
    Show,
    Hide
}

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<GameObject> _listPanel = new List<GameObject>();
    [SerializeField] private TypePanelUI _currentUIState = TypePanelUI.MainMenu;
    
    public TypePanelUI _CurrentUIState
    {
        get
        {
            return _currentUIState;
        }
    }

    public UnityAction<bool> _AutoShootingUI, _Joystick;

    private void Start()
    {
        SetPanelState(_currentUIState, PanelState.Show);
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

    private void ShowPanel()
    {
        GameObject panel = _listPanel.Where(obj => obj.name == _currentUIState.ToString()).SingleOrDefault();
        if (panel == null) return;
        panel.SetActive(true);
    }

    private void HidePanel()
    {
        GameObject panel = _listPanel.Where(obj => obj.name == _currentUIState.ToString()).SingleOrDefault();
        if (panel == null) return;
        panel.SetActive(false);
    }

    public void SetPanelState(TypePanelUI typePanel, PanelState statePanel)
    {
        _currentUIState = typePanel;
        switch (statePanel)
        {
            case PanelState.Show:
                ShowPanel();
                break;

            case PanelState.Hide:
                HidePanel();
                break;

            default:
                break;
        }
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
        Transform parent = this.transform;
        foreach (Transform item in parent)
        {
            item.gameObject.SetActive(false);
            _listPanel.Add(item.gameObject);
        }
    }
}
