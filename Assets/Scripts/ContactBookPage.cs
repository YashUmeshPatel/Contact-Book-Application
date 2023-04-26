using UnityEngine.UI;

public class ContactBookPage : BaseClass
{    
    public Button BackButton;
    public Button LoginButton;

    public void BackButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.ContactBookPage);        
    }
    public void LoginButton_OnClick()
    {
        Data.inst.LoginValidate();

        if (Data.inst.isValid)
            ScreenManager.instance.showNextScreen(Screen.ContactsPage);
    }

    public void Start()
    {            
        BackButton.onClick.AddListener(BackButton_OnClick);
        LoginButton.onClick.AddListener(LoginButton_OnClick);
    }   
}