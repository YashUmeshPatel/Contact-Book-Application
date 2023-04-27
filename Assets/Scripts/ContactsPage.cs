using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactsPage : BaseClass
{
    public Button BackButton;
    
    public void BackButton_OnClick()
    {
        Debug.Log("Back Pressed");
        Data.inst.test2();
        ScreenManager.instance.showNextScreen(Screen.ContactBookPage);
    }

    public void Start()
    {
        BackButton.onClick.AddListener(BackButton_OnClick);
    }
}