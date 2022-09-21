using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int damage;
    [Header("Players")]
    [SerializeField] private PlayerHealth health;
    [SerializeField] private PlayerHealth health2;
    [SerializeField] private PlayerHealth health3;
    [SerializeField] private PlayerHealth health4;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.currentHealth -= damage;
        }
        else if (other.CompareTag("Player2"))
        {
            health2.currentHealth -= damage;
        }
        else if (other.CompareTag("Player3"))
        {
            health3.currentHealth -= damage;
        }
        else if (other.CompareTag("Player4"))
        {
            health4.currentHealth -= damage;
        }
    }
}
