using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageArea : BaseMonoBehaviour
{
    [SerializeField] private List<Transform> _listPage = new List<Transform>();

    protected override void SetDefaultValue()
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        Transform pages = this.transform;

        foreach (Transform item in pages)
        {
            _listPage.Add(item);
        }
    }
}
