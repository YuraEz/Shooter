using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public float Speed;
    public float SquattingSpeed;
    public bool Squatting;

    public Rigidbody RB;
    //public Camera PlayerCamera;
    //public Transform Camera;

    private JumpingController Jumping;

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
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        Squatting = false;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) Squatting = true;

        

        float MoveX = Input.GetAxis("Horizontal");
        float MoveZ = Input.GetAxis("Vertical");

        Vector3 Movement = transform.forward * MoveZ + transform.right * MoveX;
        if (Squatting)
        {       
            SquattingController.Instance.CmdSquatMovePlayer(Movement, SquattingSpeed);
        }
        else
        {
            MovementController.Instance.CmdMovePlayer(Movement, Speed);
        }


        //RB.velocity = new Vector3(Movement.x * Speed, RB.velocity.y, Movement.z * Speed);

        /*float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, MouseX, 0);

        XAngle -= MouseY;
        XAngle = Mathf.Clamp(XAngle, -90, 90);
        PlayerCamera.transform.localRotation = Quaternion.Euler(XAngle, 0, 0);*/

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, -transform.up, JumpCheckDistance, GroundMask))
        {
            //RB.AddForce(transform.up * JumpForse);
            Jumping.CmdJumpPlayer(JumpForse);
            //CmdJumpPlayer();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponsManager.Instance.ChangeWeapon("Gun");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponsManager.Instance.ChangeWeapon("Machete");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponsManager.Instance.ChangeWeapon("Pistol");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponsManager.Instance.ChangeWeapon("Flashbang");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            WeaponsManager.Instance.ChangeWeapon("Grenade");
        }
    }





    /*[Command]
    private void CmdJumpPlayer()
    {
        RB.AddForce(transform.up * JumpForse);
    }*/
}
