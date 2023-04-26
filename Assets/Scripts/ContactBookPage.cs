using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContactBookPage : BaseClass
{
    public Button SubmitButton;
    public Button BackButton;

    public void SubmitButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.ContactBookPage);
        //Data.inst.addRegistrationData();
        //Data.inst.LoadData();
        //Data.inst.Save();
    }

    public void BackButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.ContactBookPage);        
    }

    public void Start()
    {
        SubmitButton.onClick.AddListener(SubmitButton_OnClick);     
        BackButton.onClick.AddListener(BackButton_OnClick);
    }   
}