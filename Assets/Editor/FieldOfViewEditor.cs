using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(EnemyLineOfSight))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyLineOfSight los = (EnemyLineOfSight)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(los.transform.position, Vector3.forward, Vector3.up, 360, los.viewRadius);

        //Vector2 viewAngleA = los.DirFromAngle(-los.viewAngle / 2, false);
        //Vector2 viewAngleB = los.DirFromAngle(los.viewAngle / 2, false);

        //Handles.DrawLine(los.transform.position, new Vector3(los.transform.position.x + viewAngleA.x * los.viewRadius, los.transform.position.y + viewAngleA.y * los.viewRadius, 0));
        //Handles.DrawLine(los.transform.position, new Vector3(los.transform.position.x + viewAngleB.x * los.viewRadius, los.transform.position.y + viewAngleB.y * los.viewRadius, 0));

        Handles.color = Color.red;
        foreach(Transform visibleTargets in los.visibleTargets)
        {
            Handles.DrawLine(los.transform.position, visibleTargets.position);
        }
    }
}
