using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : NetworkBehaviour
{
    public Rigidbody RB;
    public static MovementController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Command(requiresAuthority = false)]
    public void CmdMovePlayer(Vector3 Movement, float Speed)
    {
        RB.velocity = new Vector3(Movement.x * Speed, RB.velocity.y, Movement.z * Speed);
    }
}
