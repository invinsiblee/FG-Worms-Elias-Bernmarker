using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject crossedOut;
    [SerializeField] private GameManager manager;
    public int currentHealth;
    [HideInInspector] public bool dead;
    
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
            dead = true;
            crossedOut.SetActive(true);
        }
    }
}
