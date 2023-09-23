using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { SwitchTeam, Active, Dead }

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;



    [SerializeField]private PlayerState state;
    private UIManager UI;
    private Player LocalPlayer;

    public void Awake()
    {
        Instance = this;
    }


    public void Init()
    {
        LocalPlayer = Player.LocalPlayer;
        UI = UIManager.Instance;
        ChangeState(PlayerState.SwitchTeam);
    }

    public void ChangeState(PlayerState newState)
    {
        state = newState;
        switch(state)
        {
            case PlayerState.SwitchTeam:
                UI.ChangeScreen("Match");
                LocalPlayer.gameObject.SetActive(false);
                break;
            case PlayerState.Active:
                UI.ChangeScreen("Hud");
                LocalPlayer.gameObject.SetActive(true);
                break;
        }
    }
}
