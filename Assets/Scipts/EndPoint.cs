using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Agent agent)) // other.TryGetComponent<Agent>(out Agent agent)
        {
            agent.OnHitEndPoint();
        }    
    }
}
