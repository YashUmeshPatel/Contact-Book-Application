using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterPage : BaseClass
{
    public TMP_InputField userId, password;    

    [SerializeField] private Button RegisterButton;
    [SerializeField] private Button SubmitButton; 

    public void RegisterButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.RegisterPage);
    }

    public void SubmitButton_OnClick()
    {
        Data.inst.AddRegistrationData(userId.text, password.text);
        ScreenManager.instance.showNextScreen(Screen.ContactBookPage);        
    }

    public void Start()
    {
        SubmitButton.onClick.AddListener(SubmitButton_OnClick);
        RegisterButton.onClick.AddListener(RegisterButton_OnClick);        
    }
}