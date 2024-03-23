using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Agent : MonoBehaviour
{
    [SerializeField, HideInInspector] NavMeshAgent navMeshAgent;   
    [SerializeField] float startHealth = 100;
    [SerializeField] int agentValue = 10;
    [SerializeField] int agentDamage = 1;

    float currentHealth;

    public event Action HelathChanged; 

    public float HealthRate => currentHealth / startHealth;

    private void OnValidate()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EndPoint ep = FindAnyObjectByType<EndPoint>();
        navMeshAgent.destination = ep.transform.position;
        currentHealth = startHealth;
        HelathChanged?.Invoke();
    }

    public void OnHitEndPoint()
    {
        GameManager.Damage(agentDamage);

        Destroy(gameObject);
    }

    internal void Damage(float damage)
    {
        currentHealth -= damage;
        HelathChanged?.Invoke();

        if(currentHealth <= 0)
        {
            GameManager.Money += agentValue;
            Debug.Log("Agent Died!");
            Destroy(gameObject);
        }
    }
}
