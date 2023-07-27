using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : Singleton<FullScreen>
{
    [SerializeField] private Camera _cam;
    [SerializeField] private float _heightCamera = 0;
    [SerializeField] private float _widthCamera = 0;
    [SerializeField] private BoxCollider2D _boxCollider2D;
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

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCamera();
        LoadBoxCollider2D();
    }

    private void LoadCamera()
    {
        _cam = Camera.main;
        _HeightCamera = 2f * _cam.orthographicSize;
        _WidthCamera = _HeightCamera * _cam.aspect;
    }

    private void LoadBoxCollider2D()
    {
        _boxCollider2D = this.GetComponent<BoxCollider2D>();
        _boxCollider2D.size = new Vector2(_widthCamera, _heightCamera);
    }
}
