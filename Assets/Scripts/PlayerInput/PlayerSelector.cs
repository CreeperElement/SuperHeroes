using Assets.Scripts.PlayerInput;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FighterInput))]
public class PlayerSlector : Editor
{
    List<string> _choices;
    int _choiceIndex = 0;

    private void Awake()
    {
        _choices = new List<string>();
        PlayerManager manager = PlayerManager.GetInstance();
        for(int i = 1; i <= manager.MaxNumPlayers; i++ )
        {
            _choices.Add($"Player{i}");
        }
    }

    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.ToArray());
        var someClass = target as FighterInput;
        // Update the selected choice in the underlying object
        someClass.PlayerNumber = _choices[_choiceIndex];
        // Save the changes back to the object
        EditorUtility.SetDirty(target);
    }
}
