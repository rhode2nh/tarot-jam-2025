using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ModularSnapConfig))]
public class ModularSnapConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ModularSnapConfig config = (ModularSnapConfig)target;
        
        EditorGUILayout.Space(10);
        if (GUILayout.Button("Recalculate Wall Thickness"))
        {
            config.CalculateWalls();
        }
        if (GUILayout.Button("Recalculate Floor Thickness"))
        {
            config.CalculateFloors();
        }
    }
    
}
