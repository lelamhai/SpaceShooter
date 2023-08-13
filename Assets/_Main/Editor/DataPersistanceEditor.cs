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

        if (GUILayout.Button("Open Data"))
        {
            DataPersistanceManager.Instance.OpenFolder();
        }
    }
}
