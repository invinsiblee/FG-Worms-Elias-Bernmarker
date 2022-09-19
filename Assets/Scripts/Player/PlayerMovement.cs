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

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movement;
    private float turn;
    private bool aimDown;

    private Rigidbody rb;

    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera normalCam;
    [SerializeField] private CinemachineFreeLook aimCam;
    [SerializeField] private GameObject crosshair;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //MovePlayer();
        Aim();
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);
            
        MyInput();
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        aimDown = Input.GetButton("Fire2");

        if (Input.GetButton("Jump") && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    void Move()
    {
        movement = new Vector3(0, 0, verticalInput * moveSpeed * Time.deltaTime);
        var moveDirection = transform.TransformDirection(movement);
        rb.MovePosition(transform.position + moveDirection);
    }

    void Turn()
    {
        turn = horizontalInput * rotateSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Aim()
    {
        if (aimDown)
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
