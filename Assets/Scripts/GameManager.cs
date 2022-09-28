using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int players = 1;

    private MyInput myInput;

    [Header("Player scripts")] 
    [SerializeField] private PlayerMovement[] move;
    [SerializeField] private ShootingLogic[] shoot;

    [Header("Cameras")] 
    [SerializeField] private CinemachineVirtualCamera cam1;
    [SerializeField] private CinemachineFreeLook cam2;

    [Header("AimCam")] 
    [SerializeField] private Transform[] aim;

    [Header("Players")] 
    [SerializeField] private PlayerHealth[] health;

    void Start()
    {
        myInput = GetComponent<MyInput>();
    }

    void Update()
    {
        if (myInput.nextTurn || myInput.aimDown && myInput.shoot)
        {
            NextTurn();
        }
    }

    public void NextTurn()
    {
        for (int i = 0; i < move.Length; i++)
        {
            move[i].enabled = false;
            shoot[i].enabled = false;
        }

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

    void Player1()
    {
        if (health[0].dead)
        {
            players++;
            Player2();
        }
        else
        {
            move[0].enabled = true;
            shoot[0].enabled = true;
        
            cam1.LookAt = move[0].transform;
            cam2.LookAt = aim[0];
            cam1.Follow = move[0].transform;
            cam2.Follow = move[0].transform; 
        }
    }

    void Player2()
    {
        if (health[1].dead)
        {
            players++;
            Player3();
        }
        else
        {
            move[1].enabled = true;
            shoot[1].enabled = true;
        
            cam1.LookAt = move[1].transform;
            cam2.LookAt = aim[1];
            cam1.Follow = move[1].transform;
            cam2.Follow = move[1].transform;
        }
    }

    void Player3()
    {
        if (health[2].dead)
        {
            players++;
            Player4();
        }
        else
        {
            move[2].enabled = true;
            shoot[2].enabled = true;
        
            cam1.LookAt = move[2].transform;
            cam2.LookAt = aim[2];
            cam1.Follow = move[2].transform;
            cam2.Follow = move[2].transform;
        }
    }

    void Player4()
    {
        players = 0;
        if (health[3].dead)
        {
            Player1();
        }
        else
        {
            move[3].enabled = true;
            shoot[3].enabled = true;
        
            cam1.LookAt = move[3].transform;
            cam2.LookAt = aim[3];
            cam1.Follow = move[3].transform;
            cam2.Follow = move[3].transform;
        }
    }
}
