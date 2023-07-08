using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDisappear : MonoBehaviour
{
    [SerializeField] private const float DISTANCE = 20;
    [SerializeField] private float _cureentDistance = 0;

    private void Update()
    {
        _cureentDistance = Vector3.Distance(this.transform.position, Vector3.zero);
        if (_cureentDistance < DISTANCE) return;
        Disappear();
        DisappearGameObject();
    }

    protected abstract void DisappearGameObject();

    private void Disappear()
    {
        this.gameObject.SetActive(false);
    }

    
}
