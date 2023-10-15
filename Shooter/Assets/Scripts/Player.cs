using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public float Speed;
    public float SquattingSpeed;
    public bool SquattingCheck;

    public Rigidbody RB;
    //public Camera PlayerCamera;
    //public Transform Camera;

    private JumpingController Jumping;
    private MovementController Moving;
    private SquattingController Squatting;

    private float XAngle;
    public float JumpForse;
    public float JumpCheckDistance;
    public LayerMask GroundMask;

    public static Player LocalPlayer;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        if (isLocalPlayer) 
        {
            LocalPlayer = this;
            PlayerManager.Instance.Init();
        }


        Jumping = JumpingController.Instance;
        Moving = MovementController.Instance;
        Squatting = SquattingController.Instance;
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        SquattingCheck = false;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) SquattingCheck = true;

        

        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 Movement = transform.forward * MoveZ + transform.right * MoveX;
        if (SquattingCheck)
        {
            Squatting.CmdSquatMovePlayer(Movement, SquattingSpeed);
        }
        else
        {
            Moving.CmdMovePlayer(Movement, Speed);
        }



        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, JumpCheckDistance, GroundMask))
        {
            Jumping.CmdJumpPlayer(JumpForse);
        }
    }
}
