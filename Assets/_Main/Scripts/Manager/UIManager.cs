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
    LevelSelect,
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
    public UnityAction<int, int> _HealthPlayer;
    public UnityAction<bool> _Joystick;
    [SerializeField] private List<GameObject> _listPanel = new List<GameObject>();
    [SerializeField] private TypePanelUI _currentUIState = TypePanelUI.MainMenu;
    [SerializeField] private JoystickSO _joystick;
    public TypePanelUI _CurrentUIState
    {
        get
        {
            return _currentUIState;
        }
    }

    private void Start()
    {
        SetPanelState(_currentUIState, PanelState.Show);
        #if UNITY_EDITOR
            _joystick._userJoystick = false;
        #endif

        #if UNITY_IOS
             _joystick._userJoystick = true;
        #endif

        #if UNITY_ANDROID
            _joystick._userJoystick = true;
        #endif

        #if UNITY_STANDALONE_OSX
            _joystick._userJoystick = false;
        #endif

        #if UNITY_STANDALONE_WIN
            _joystick._userJoystick = false;
        #endif
    }

    private void OnEnable()
    {
        GameManager.Instance._GameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.Instance._GameOver -= GameOver;
    }

    private void GameOver()
    {
        StartCoroutine(IEGameOver());
    }

    private IEnumerator IEGameOver()
    {
        yield return new WaitForSeconds(2f);
        SetPanelState(TypePanelUI.GameOver, PanelState.Show);
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

    public void HealthPlayer(int currentHealth, int maxHealth)
    {
        _HealthPlayer?.Invoke(currentHealth, maxHealth);
    }

    public void SetJoystick(bool active)
    {
        _joystick._userJoystick = active;
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAllUI();
        LoadJoystick();
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

    private void LoadJoystick()
    {
        string path = "Joystick/JoystickSO";
        _joystick = Resources.Load<JoystickSO>(path);
    }
}
