using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameObject crossedOut;
    public int currentHealth;
    [HideInInspector] public bool dead;
    [SerializeField] private GameManager manager;

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
            transform.position = new Vector3(-10, -10, -10);
            crossedOut.SetActive(true);
            manager.deathCounter++;
            manager.NextTurn();
            enabled = false;
        }
    }
}
