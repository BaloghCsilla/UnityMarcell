using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Agent agent;
    [SerializeField] Image healthImage;


    private void Start()
    {
        agent.HelathChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        agent.HelathChanged -= OnHealthChanged;
    }

    // Update is called once per frame
    void Update()
    {        
        transform.LookAt(Camera.main.transform.position);
    }

    private void OnHealthChanged() => UpdateUI(agent.HealthRate);
    
    public void UpdateUI(float healthRate)
    {
        healthImage.fillAmount = healthRate;
    }
}
