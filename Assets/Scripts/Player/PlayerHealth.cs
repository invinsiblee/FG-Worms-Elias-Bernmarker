using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        CheckPlayerHealth();
    }

    void CheckPlayerHealth()
    {
        if (currentHealth <= 0)
        {
            //death animation
            //Set active UI
        }
    }
}
