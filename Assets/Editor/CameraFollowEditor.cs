using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor
{
    //Source: https://www.youtube.com/watch?v=UmmfNGjWl2g&list=PLq3pyCh4J1B2va_ftIthSpUaQH0LycRA-&index=9
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cf = (CameraFollow)target;
        if(GUILayout.Button("Set Min Cam Pos"))
        {
            cf.SetMinCamPosition();
        }

        if(GUILayout.Button("Set Max Cam Pos"))
        {
            cf.SetMaxCamPosition();
        }
    }
}
