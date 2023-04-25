using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewContactPage : BaseClass
{
    public Button AddContactButton;    

    public void AddContactButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.NewContactPage);
    }   

    public void Start()
    {
        AddContactButton.onClick.AddListener(AddContactButton_OnClick);       
    }
}