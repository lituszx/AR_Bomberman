using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LevelEditor))]
public class EditorBuild : Editor
{
    private bool oldInspector = false;
    private bool editingButtons = false;
    public override void OnInspectorGUI()
    {
        GUILayout.Space(5);
        LevelEditor lvlEditor = (LevelEditor)target;
        editingButtons = EditorGUILayout.Foldout(editingButtons, "Current Level Edited");
        if (editingButtons)
        {
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Editing Level:" + lvlEditor.LevelData.level);
            if (GUILayout.Button("Level Down", GUILayout.Width(50), GUILayout.Height(20)))
            {
                lvlEditor.LevelData.level--;
            }
            if (GUILayout.Button("Level Up", GUILayout.Width(50), GUILayout.Height(20)))
            {
                lvlEditor.LevelData.level++;
            }
            if (lvlEditor.LevelData.level < 1)
                lvlEditor.LevelData.level = 1;
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Add Boxes to Data");
            if(GUILayout.Button("Add Boxes", GUILayout.Width(90), GUILayout.Height(20)))
            {
                lvlEditor.SetBoxes();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Add Bricks to Data");
            if (GUILayout.Button("Add Bricks", GUILayout.Width(90), GUILayout.Height(20)))
            {
                lvlEditor.SetBricks();
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Add Enemies to Data");
            if (GUILayout.Button("Add Enemies", GUILayout.Width(90), GUILayout.Height(20)))
            {
                lvlEditor.SetEnemys();
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Save Level", GUILayout.Width(90), GUILayout.Height(20)))
            {
                lvlEditor.SaveData();
            }
            if (GUILayout.Button("Load Level", GUILayout.Width(90), GUILayout.Height(20)))
            {
                lvlEditor.LoadData();
            }
        }
        oldInspector = EditorGUILayout.Foldout(oldInspector, "References");
        if (oldInspector)
            DrawDefaultInspector();
    }
}
