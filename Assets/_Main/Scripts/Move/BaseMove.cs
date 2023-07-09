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

    public void SetRotation(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Option 1
        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0,0,angle));
        //this.transform.rotation = targetRotation;

        //Option 2
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
