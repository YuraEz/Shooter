using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchJoinView : MonoBehaviour
{
    public Button JoinFirstCmdBtn;
    public Button JoinSecondCmdBtn;

    public void Start()
    {
        JoinFirstCmdBtn.onClick.AddListener(JoinFirstCmd);
        JoinSecondCmdBtn.onClick.AddListener(JoinSecondCmd);
    }

    private void JoinFirstCmd()
    {
        MatchManager.Instance.JoinTeam(0);
        PlayerManager.Instance.ChangeState(PlayerState.Active);
    }

    private void JoinSecondCmd()
    {
        MatchManager.Instance.JoinTeam(1);
        PlayerManager.Instance.ChangeState(PlayerState.Active);
    }
}
