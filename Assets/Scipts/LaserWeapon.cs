using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour
{
    [SerializeField] float range = 2;
    [SerializeField] float damageRate = 10;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField, Min(2)] int laserPointCount = 10; 

    Agent closest = null;

    private void Update()
    {
        if (closest != null && !IsInRange(closest))
            closest = null;

        if (closest == null)
            closest = FindClosestAngentInRange();    

        if (closest!= null)
        {             
                closest.Damage(damageRate * Time.deltaTime);
        }

        UpdateLaserVisual();
    }

    private void UpdateLaserVisual()
    {
        lineRenderer.enabled = closest != null;
        if (closest == null) return;

        lineRenderer.positionCount = laserPointCount;

        lineRenderer.SetPosition(0, transform.position);
        Vector3 a = transform.position;
        Vector3 b = closest.transform.position;
        Vector3 step = (b - a) / (laserPointCount - 1);

        for (int i=0; i < laserPointCount; i++)
        {
            lineRenderer.SetPosition(i, a);
            a += step;
        }
    }

    private Agent FindClosestAngentInRange()
    {
        Agent[] allAgents = FindObjectsOfType<Agent>();
       
        Vector3 weaponPos = transform.position;
        float minDistance = float.MaxValue;
        Agent closest = null;

        foreach (Agent agent in allAgents)
        {
            Vector3 agentPos = agent.transform.position;
            float distance = Vector3.Distance(agentPos, weaponPos);

            if (distance > range) continue;
            if (distance > minDistance) continue;

            minDistance = distance;
            closest = agent;
        }

        return closest;        
    }

    private bool IsInRange(Agent agent)
    {
        Vector3 weaponPos = transform.position;
        float distance = Vector3.Distance(agent.transform.position, weaponPos);
        return distance <= range;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (closest != null)
            Debug.DrawLine(closest.transform.position, transform.position, Color.red);
    }
}


