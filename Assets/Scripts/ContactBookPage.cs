using UnityEngine.UI;

public class ContactBookPage : BaseClass
{        
    public Button LoginButton;
    
    public void LoginButton_OnClick()
    {
        Data.inst.LoginValidate();

        if (Data.inst.isValid)
            ScreenManager.instance.showNextScreen(Screen.ContactsPage);
    }

    public void Start()
    {                    
        LoginButton.onClick.AddListener(LoginButton_OnClick);
    }   
}