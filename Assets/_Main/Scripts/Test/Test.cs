using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TMP_Text _label;

    private int _count = 0;

    private void Start()
    {
        SetLabel();
    }

    private void SetLabel()
    {
        _label.text = _count.ToString();
    }

    public void ButtonPlus()
    {
        _count++;
        SetLabel();
    }

    public void LoadData(GameData data)
    {
        //this._count = data._Count;
    }

    public void SaveData(GameData data)
    {
        //data._Count = _count;
    }
}
