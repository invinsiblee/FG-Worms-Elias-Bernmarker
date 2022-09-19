using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private float power = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.AddForce(0,power,0, ForceMode.Impulse);
        }
    }
}
