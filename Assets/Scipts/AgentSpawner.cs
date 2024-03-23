using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] Agent agentPrefab;
    [SerializeField] int count = 10;
    [SerializeField] float duration = 1;

    private void Start()
    {
        StartCoroutine(SpawnAll());
    }

    IEnumerator SpawnAll()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(duration);
            Spawner();
        }
    }

    private void Spawner()
    {
        Agent agent = Instantiate(agentPrefab, transform.position, transform.rotation, transform);
    }
}
