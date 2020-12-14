using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(BoolStateSO), true)]
public class BoolStateSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var tar = target as BoolStateSO;
        if (tar != null)
        {
            GUI.enabled = false;
            GUILayout.Toggle(tar.IsOn, "Is ON");
            GUI.enabled = true;

            if (GUILayout.Button("Change"))
            {
                tar.Change();
            }
        }
    }

}
