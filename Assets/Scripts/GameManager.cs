using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //activate the playermovement 
    //change camera active

    private int players = 1;

    private MyInput myInput;

    [Header("Players")] 
    [SerializeField] private PlayerMovement move1;
    [SerializeField] private PlayerMovement move2;
    [SerializeField] private PlayerMovement move3;
    [SerializeField] private PlayerMovement move4;

    [Header("Cameras")] 
    [SerializeField] private CinemachineFreeLook cam2;
    [SerializeField] private CinemachineVirtualCamera cam1;

    [Header("AimCam")] 
    [SerializeField] private Transform aim1;
    [SerializeField] private Transform aim2;
    [SerializeField] private Transform aim3;
    [SerializeField] private Transform aim4;

    [Header("Boundaries")] 
    [SerializeField] private GameObject bound1;
    [SerializeField] private GameObject bound2;
    [SerializeField] private GameObject bound3;
    [SerializeField] private GameObject bound4;
    
    void Start()
    {
        myInput = GetComponent<MyInput>();
    }

    void Update()
    {
        NextTurn();
    }

    void NextTurn()
    {
        if (myInput.nextTurn)
        {
            move1.enabled = false;
            move2.enabled = false;
            move3.enabled = false;
            move4.enabled = false;
            
            players++;
            if (players == 1)
            {
                Player1();
            }
            else if (players == 2)
            {
                Player2();
            }
            else if (players == 3)
            {
                Player3();
            }
            else if (players == 4)
            {
                Player4();
            }
        }
    }

    void Player1()
    {
        move1.enabled = true;
        
        cam1.LookAt = move1.transform;
        cam2.LookAt = aim1;
        cam1.Follow = move1.transform;
        cam2.Follow = move1.transform;

        bound1.transform.position = move1.transform.position;
    }

    void Player2()
    {
        move2.enabled = true;
        
        cam1.LookAt = move2.transform;
        cam2.LookAt = aim2;
        cam1.Follow = move2.transform;
        cam2.Follow = move2.transform;
    }

    void Player3()
    {
        move3.enabled = true;
        
        cam1.LookAt = move3.transform;
        cam2.LookAt = aim3;
        cam1.Follow = move3.transform;
        cam2.Follow = move3.transform;
    }

    void Player4()
    {
        move4.enabled = true;
        
        cam1.LookAt = move4.transform;
        cam2.LookAt = aim4;
        cam1.Follow = move4.transform;
        cam2.Follow = move4.transform;
        
        players = 0;
    }
}