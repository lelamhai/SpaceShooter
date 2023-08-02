using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePlayer : BaseMove
{
    [SerializeField] private Vector2 _StartGamePoint = new Vector2(0, -3);
    [SerializeField] private Vector2 _EndGamePoint = new Vector2(0, 7);
    [SerializeField] private Vector2 _currentPos = Vector2.zero;

    private float _screenX = 0;
    private float _screenY = 0;

    private void Start()
    {
        LoadWidthHeight();
        StartGame();
    }

    private void OnEnable()
    {
        GameManager.Instance._EndLevel += EndLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._EndLevel -= EndLevel;
    }
    private void StartGame()
    {
        StartCoroutine(MoveStartGame(_StartGamePoint, (isFinish)=> {
            _canMove = isFinish;
            if (!isFinish) return;
            _canMove = true;
            GameManager.Instance.SetGameState(GameStates.StartGame);
        }));
    }

    private void EndLevel()
    {
        _canMove = false;
        StartCoroutine(MoveStartGame(_EndGamePoint, (isFinish) =>
        {
            _canMove = isFinish;
            if (!isFinish) return;
            _canMove = true;
            GameManager.Instance.SetGameState(GameStates.NextLevel);
        }));
    }

    private IEnumerator MoveStartGame(Vector2 startGame,UnityAction<bool> callback)
    {
        this.transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.001f);
        if(this.transform.position.y < startGame.y)
        {
            StartCoroutine(MoveStartGame(startGame, callback));
            callback(false);
        } else
        {
            StopCoroutine(MoveStartGame(startGame, callback));
            callback(true);
        }
    }

    protected override void Movement(Vector3 position)
    {
        if (!_canMove) return;
        _currentPos = InputManager.Instance._MovePos;
        Vector2 direction = _currentPos.normalized;
        Vector2 pos = this.transform.position;
        pos += direction * _moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -_screenX, _screenX);
        pos.y = Mathf.Clamp(pos.y, -_screenY, _screenY);
        this.transform.position = pos;
    }

    private void LoadWidthHeight()
    {
        _screenX = FullScreen.Instance._WidthCamera / 2;
        _screenY = FullScreen.Instance._HeightCamera / 2;
    }

    protected override void SetDefaultValue()
    {
        _moveSpeed = 4f;
        _canMove = false;
    }
}
