using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {
            playerObj.forward =
                Vector3.Slerp(playerObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
