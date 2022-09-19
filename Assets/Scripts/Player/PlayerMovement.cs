using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    private bool readyToJump = true;
    
    [Header("Ground Check")] 
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask WhatIsGround;
    private bool grounded;

    private float horizontalInput;
    private float verticalInput;
    private bool aimDown;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
        if (aimDown == true)
        {
            Aim();
        }

        gravity += Physics.gravity.y * Time.deltaTime;
        if (gravity <= 0)
        {
            gravity = 0;
        }
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);
            
        MyInput();
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

    private void MovePlayer()
    {
        if (grounded)
        {
            transform.Rotate(0, horizontalInput * rotateSpeed * Time.deltaTime, 0);
            transform.Translate(0, 0, verticalInput * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(0, 0, verticalInput * moveSpeed * airMultiplier * Time.deltaTime);
        }
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
        //Change camera
        //Lock controls
    }
}
