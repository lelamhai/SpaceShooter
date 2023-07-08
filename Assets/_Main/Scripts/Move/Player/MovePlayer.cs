using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : BaseMove
{
    private float _screenX = 0;
    private float _screenY = 0;

    private void Start()
    {
        LoadWidthHeight();
    }

    private void OnEnable()
    {
        InputManager.Instance._Movement += Movement;
    }

    private void OnDisable()
    {
        InputManager.Instance._Movement -= Movement;
    }

    protected override void Movement(Vector3 position)
    {
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
        _moveSpeed = 3f;
        _canMove = false;
    }
}
