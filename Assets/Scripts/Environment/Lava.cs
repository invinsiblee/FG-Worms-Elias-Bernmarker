using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        var Health = other.gameObject.GetComponent<PlayerHealth>();
        Health.currentHealth -= damage;
    }
}
