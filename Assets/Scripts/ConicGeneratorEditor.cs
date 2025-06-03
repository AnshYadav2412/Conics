using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ConicGenerator))]
public class ConicGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ConicGenerator generator = (ConicGenerator)target;

        if (GUILayout.Button("Square"))
        { 
        }
    }
}
