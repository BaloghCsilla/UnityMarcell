using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathwoker : MonoBehaviour
{
    [SerializeField] Vector3[] points;
    [SerializeField] Transform movingObject;
    [SerializeField] float speed = 10;
    [SerializeField] bool isLooping;
    [SerializeField] bool useGlobalSpace;

    private void Start()
    {
        movingObject.position = points[0];
    }

    Vector3 GetPoint(int index) => useGlobalSpace ? points[index] : transform.TransformPoint(points[index]);

    int index = 0;
    bool moveForward = true; 
    // Update is called once per frame
    void Update()
    {
        Vector3 target = GetPoint(index);
        float step = speed * Time.deltaTime;
        movingObject.position = Vector3.MoveTowards(movingObject.position, target, step);

        if(movingObject.position == target)
        {
            if (isLooping)
            {
                index = (index + 1) % points.Length;
            }
            else
            {
                if((moveForward && index == points.Length-1) || (!moveForward && index == 0))                
                    moveForward = !moveForward;                    
                
                index += moveForward ? 1 : -1;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (points == null) return;

        Gizmos.color = Color.blue;
        for (int i = 0; i < points.Length-1; i++)
        {
            int i2 = i + 1;
            Vector3 p1 = GetPoint(i);
            Vector3 p2 = GetPoint(i2);
            Gizmos.DrawLine(p1, p2);
        }

        if (isLooping && (points.Length >= 3)) 
        {
            Gizmos.DrawLine(GetPoint(0), GetPoint(points.Length - 1));
        }
    }
}
