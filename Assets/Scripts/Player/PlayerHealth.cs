using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject crossedOut;
    [SerializeField] private GameObject ui;
    public int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        CheckPlayerHealth();
    }

    void CheckPlayerHealth()
    {
        healthBar.SetCurrentHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //ui.SetActive(true);
            Destroy(gameObject);
            crossedOut.SetActive(true);
        }
    }
}
