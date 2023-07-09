using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWidthHeight : Singleton<ScreenWidthHeight>
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _heightCamera = 0;
    [SerializeField] private float _widthCamera = 0;
    public float _HeightCamera
    {
        get { return _heightCamera; }
        set { _heightCamera = value; }
    }
    public float _WidthCamera
    {
        get { return _widthCamera; }
        set { _widthCamera = value; }
    }

    private void LoadCamera()
    {
        _cam = Camera.main;
        _HeightCamera = 2f * _cam.orthographicSize;
        _WidthCamera = _HeightCamera * _cam.aspect;
    }

    protected override void SetDefaultValue()
    { }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCamera();
    }
}
