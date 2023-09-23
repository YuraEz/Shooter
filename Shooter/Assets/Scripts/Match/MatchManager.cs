using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : NetworkBehaviour
{

    public static MatchManager Instance;

    public List<MatchTeam> MatchTeams;

    public void Awake()
    {
        Instance = this;
    }

    [Command(requiresAuthority = false)]
    public void CmdJoinTeam(int playerId, int teamIndex)
    {
        //if (CheckPlayerIn(playerId)) return;
        MatchTeams[teamIndex].PlayersId.Add(playerId);
        NetworkServer.connections[playerId].identity.transform.position = MatchTeams[teamIndex].TeamCenter.position;
        
    }

    public void JoinTeam(int teamIndex)
    {
        CmdJoinTeam(NetworkClient.connection.connectionId, teamIndex);
    }





    /*private bool CheckPlayerIn(uint playerId)
    {
        foreach (uint playerFromFirstCmd in FirstCmdPlayers)
        {
            if (playerFromFirstCmd == playerId) 
            {
                return true;
            }
        }
        foreach (uint playerFromSecondCmd in SecondCmdPlayers)
        {
            if (playerFromSecondCmd == playerId)
            {
                return true;
            }
        }
        return false;*/
    

}
