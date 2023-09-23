using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquattingController : NetworkBehaviour
{
    public Rigidbody RB;
    public static SquattingController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Command(requiresAuthority = false)]
    public void CmdSquatMovePlayer(Vector3 Movement, float SquattingSpeed)
    {
        RB.velocity = new Vector3(Movement.x * SquattingSpeed, RB.velocity.y, Movement.z * SquattingSpeed);
    }
}
