using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyFieldOfView))]
public class FieldOfViewEditor1 : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.GetViewRadius());
        Vector3 viewAnglesA= fow.DirFromAngle(-fow.GetViewAngle()/2, false );
        Vector3 viewAnglesB = fow.DirFromAngle(fow.GetViewAngle()/2, false );
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAnglesA * fow.GetViewRadius());
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAnglesB * fow.GetViewRadius());
        
        
    }
}
