using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePlayer : BaseMove
{
    [SerializeField] private Vector2 _StartGamePoint = new Vector2(0, -3);
    [SerializeField] private Vector2 _EndGamePoint = new Vector2(0, 7);

    private float _screenX = 0;
    private float _screenY = 0;

    private void Start()
    {
        LoadWidthHeight();
        StartGame();
    }

    private void OnEnable()
    {
        InputManager.Instance._Movement += Movement;
    }

    private void OnDisable()
    {
        InputManager.Instance._Movement -= Movement;
    }

    private void StartGame()
    {
        StartCoroutine(MoveStartGame((isFinish)=> {
            _canMove = isFinish;
            if (!isFinish) return;
            _canMove = true;
            GameManager.Instance.SetGameState(GameStates.StartGame);
        }));
    }

    private IEnumerator MoveStartGame(UnityAction<bool> callback)
    {
        this.transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.001f);
        if(this.transform.position.y < _StartGamePoint.y)
        {
            StartCoroutine(MoveStartGame(callback));
            callback(false);
        } else
        {
            StopCoroutine(MoveStartGame(callback));
            callback(true);
        }
    }

    protected override void Movement(Vector3 position)
    {
        if (!_canMove) return;
        Vector2 direction = position.normalized;
        Vector2 pos = this.transform.position;
        pos += direction * _moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -_screenX, _screenX);
        pos.y = Mathf.Clamp(pos.y, -_screenY, _screenY);
        this.transform.position = pos;
    }

    private void LoadWidthHeight()
    {
        _screenX = ScreenWidthHeight.Instance._WidthCamera / 2;
        _screenY = ScreenWidthHeight.Instance._HeightCamera / 2;
    }

    protected override void SetDefaultValue()
    {
        _moveSpeed = 4f;
        _canMove = false;
    }
}
