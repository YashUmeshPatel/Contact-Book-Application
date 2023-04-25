using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPage : BaseClass
{
    public Button RegisterButton;    

    public void RegisterButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.RegisterPage);
    }    

    public void Start()
    {
        RegisterButton.onClick.AddListener(RegisterButton_OnClick);        
    }
}