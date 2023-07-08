using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMove : BaseMonoBehaviour
{
    [SerializeField] protected bool _canMove = true;
    [SerializeField] protected float _moveSpeed = 2f;
    [SerializeField] protected Vector3 _direction = Vector3.zero;

    private void Update()
    {
        if (!_canMove) return;
        Movement(_direction);
    }

    protected abstract void Movement(Vector3 pos);
}
