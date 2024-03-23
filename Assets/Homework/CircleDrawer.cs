using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    [SerializeField] Vector3 center;
    [SerializeField] float randius = 1;
    [SerializeField, Min(3)] int pointCount = 100;

    private void OnDrawGizmos()
    {
        float deltaAngle = 2 * Mathf.PI / pointCount;   // 2 * Mathf.PI = 360f

        for (int i = 0; i < pointCount; i++)
        {
            float angle1 = i *  deltaAngle;
            float angle2 = ((i + 1) % pointCount) * deltaAngle;
            Vector3 p1 = GetPoint(angle1);
            Vector3 p2 = GetPoint(angle2);
            Gizmos.DrawLine(p1, p2);
        }
    }

    private Vector3 GetPoint(float angle)
    {
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
        return (new Vector3(x, y) * randius) + center;
    }
}
