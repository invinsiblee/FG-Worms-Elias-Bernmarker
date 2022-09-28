using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int damage;
    [Header("Players")] 
    [SerializeField] private PlayerHealth[] health;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health[0].currentHealth -= damage;
        }
        else if (other.CompareTag("Player2"))
        {
            health[1].currentHealth -= damage;
        }
        else if (other.CompareTag("Player3"))
        {
            health[2].currentHealth -= damage;
        }
        else if (other.CompareTag("Player4"))
        {
            health[3].currentHealth -= damage;
        }
    }
}
