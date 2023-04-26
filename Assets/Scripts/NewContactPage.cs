using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewContactPage : BaseClass
{
    public TMP_InputField ContactName, ContactNumber;    

    public Button AddContactButton;
    public Button SaveButton;

    public void AddContactButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.NewContactPage);
        //Data.inst.addContacts();
    }
    public void SaveButton_OnClick()
    {
        Data.inst.AddContacts(ContactName.text, ContactNumber.text);
        ScreenManager.instance.showNextScreen(Screen.ContactsPage);
        //Data.inst.LoadData();
    }

    public void Start()
    {
        AddContactButton.onClick.AddListener(AddContactButton_OnClick);
        SaveButton.onClick.AddListener(SaveButton_OnClick);
    }
}