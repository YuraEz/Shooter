using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<UIScreen> Screens;

    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void ChangeScreen(string screenName)
    {
        foreach (UIScreen screen in Screens)
        {
            screen.gameObject.SetActive(screen.ScreenName == screenName);
        }
    }
}
