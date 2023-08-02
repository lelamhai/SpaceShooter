using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SliderLoadingUI : BaseSlider
{
    [SerializeField] private float _loading = 0;
    [SerializeField] private bool _loadFinish = false;
    private void OnEnable()
    {
        _loading = 0;
    }

    private void OnDisable()
    {
        _loadFinish = false;
    }

    private void Update()
    {
        _loading = _loading + Time.deltaTime/2;
        if(!_loadFinish)
        {
            ValueChangeCheck();
        } else
        {
            UIManager.Instance.SetPanelState(UIManager.Instance._CurrentUIState, PanelState.Hide);
            UIManager.Instance.SetPanelState(TypePanelUI.MainMenu, PanelState.Hide);
            UIManager.Instance.SetPanelState(TypePanelUI.GamePlay, PanelState.Show);

            GameManager.Instance.SetGameState(GameStates.Initialize);
        }
    }

    public override void ValueChangeCheck()
    {
        _slider.value = _loading;
        if(_loading >=_slider.maxValue)
        {
            _loadFinish = true;
        }
    }
}
