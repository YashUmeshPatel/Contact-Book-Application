using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactsPage : BaseClass
{
    public Button LoginButton;    
    public Button SaveButton;

    public void LoginButton_OnClick()
    {
        if(Data.inst.isValid)
            ScreenManager.instance.showNextScreen(Screen.ContactsPage);
    }    

    public void SaveButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.ContactsPage);
    }    

    public void Start()
    {
        LoginButton.onClick.AddListener(LoginButton_OnClick);        
        SaveButton.onClick.AddListener(SaveButton_OnClick);
    }
}