using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiChanger : MonoBehaviour
{
    public Button Btn;
    public string ScreenName;
    void Start()
    {
        Btn.onClick.AddListener(() =>
        {
            UIManager.Instance.ChangeScreen(ScreenName);
        });

    }

    

}
