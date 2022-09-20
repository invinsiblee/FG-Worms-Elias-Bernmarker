using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private Rigidbody player;
    [SerializeField] private Rigidbody player2;
    [SerializeField] private Rigidbody player3;
    [SerializeField] private Rigidbody player4;
    
    [SerializeField] private float power = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.AddForce(0,power,0, ForceMode.Impulse);
        }
        else if (other.CompareTag("Player2"))
        {
            player2.AddForce(0,power,0, ForceMode.Impulse);
        }
        else if (other.CompareTag("Player3"))
        {
            player3.AddForce(0,power,0, ForceMode.Impulse);
        }
        else if (other.CompareTag("Player4"))
        {
            player4.AddForce(0,power,0, ForceMode.Impulse);
        }
    }
}
