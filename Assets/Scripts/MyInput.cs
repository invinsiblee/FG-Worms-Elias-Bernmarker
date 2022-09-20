using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public bool aimDown;
    public bool jump;
    public bool nextTurn;
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        aimDown = Input.GetButton("Fire2");
        jump = Input.GetButton("Jump");
        nextTurn = Input.GetButtonDown("EndTurn");
    }
}
