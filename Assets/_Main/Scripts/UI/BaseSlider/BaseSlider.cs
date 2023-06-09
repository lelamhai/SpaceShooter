using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : BaseMonoBehaviour
{
    [SerializeField] protected Slider _slider;
    protected virtual void Start()
    {
        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public virtual void ValueChangeCheck()
    {
        // Override
    }

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSlider();
    }

    private void LoadSlider()
    {
        _slider = this.GetComponent<Slider>();
    }
}
