using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    private bool readyToJump = true;
    
    [Header("Ground Check")] 
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask WhatIsGround;
    private bool grounded;

    private Vector3 movement;
    private float turn;

    private Rigidbody rb;

    [Header("References")]
    [SerializeField] private MyInput myInput;
    [SerializeField] private CinemachineVirtualCamera normalCam;
    [SerializeField] private CinemachineFreeLook aimCam;
    [SerializeField] private GameObject crosshair;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Aim();
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);
            
        //MyInput();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        Jump();
    }

    void Move()
    {
        movement = new Vector3(0, 0, myInput.verticalInput * moveSpeed * Time.deltaTime);
        var moveDirection = transform.TransformDirection(movement);
        rb.MovePosition(transform.position + moveDirection);
    }

    void Turn()
    {
        turn = myInput.horizontalInput * rotateSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void Jump()
    {
        if (myInput.jump && readyToJump && grounded)
        {
            readyToJump = false;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Aim()
    {
        if (myInput.aimDown)
        {
            normalCam.Priority = 1;
            aimCam.Priority = 2;
            crosshair.SetActive(true);
        }
        else
        {
            normalCam.Priority = 2;
            aimCam.Priority = 1;  
            crosshair.SetActive(false);
        }
        
        //Lock controls
    }
}
