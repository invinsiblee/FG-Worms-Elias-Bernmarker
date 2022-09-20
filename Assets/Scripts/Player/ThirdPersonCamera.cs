using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Transform player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
    }
}
