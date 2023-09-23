using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingController : NetworkBehaviour
{
    public Rigidbody RB;
    public static JumpingController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Command(requiresAuthority = false)]
    public void CmdJumpPlayer(float jumpForse)
    {
        RB.AddForce(transform.up * jumpForse);
    }
}
