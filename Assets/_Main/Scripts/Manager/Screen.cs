using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : Singleton<Screen>
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var insideCamera = collision.GetComponent<BaseInsideCamera>();
        if (insideCamera == null) return;
        insideCamera.CollisionEnter2D(insideCamera);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerExit2D: " + collision.name);
        var insideCamera = collision.GetComponent<BaseOutsideCamera>();
        if (insideCamera == null) return;

        insideCamera.CollisionExit2D();
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("OnCollisionExit2D");
    //    var insideCamera = collision.gameObject.GetComponent<BaseOutsideCamera>();
    //    if (insideCamera == null) return;
    //    insideCamera.CollisionExit2D();
    //}

    protected override void SetDefaultValue()
    { }

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
