using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataPersistanceManager))]
public class DataPersistanceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Clear Data"))
        {
            DataPersistanceManager.Instance.ClearData();
        }
    }
}
