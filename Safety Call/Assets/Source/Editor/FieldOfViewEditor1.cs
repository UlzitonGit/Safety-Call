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
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.viewRadius);
        Vector3 viewAnglesA= fow.DirFromAngle(-fow.viewAngle/2, false );
        Vector3 viewAnglesB = fow.DirFromAngle(fow.viewAngle/2, false );
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAnglesA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAnglesB * fow.viewRadius);
        
        
    }
}
