using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ViewDetailPage : BaseClass
{
    public TMP_InputField V_ContactName;
    public TMP_InputField V_ContactNumber;

    public Button BackButton;
    public Button EditButton;

    public static ViewDetailPage inst;

    private void Awake()
    {
        inst = this;
    }
    private void Start()
    {
        EditButton.onClick.AddListener(EditButton_OnClick);
        BackButton.onClick.AddListener(BackButton_OnClick);
    }

    void EditButton_OnClick()
    {
        Data.inst.EditContact();
        Data.inst.DestroyContact();
        //Data.inst.EditData(V_ContactName.text, V_ContactNumber.text);
        Data.inst.DisplayContact();
        ScreenManager.instance.showNextScreen(Screen.ContactsPage);
    }

    void BackButton_OnClick()
    {
        ScreenManager.instance.showNextScreen(Screen.ContactsPage);
    }

    //public void AddValue(string Name, string Number)
    //{
    //    V_ContactName.text = Name;
    //    V_ContactNumber.text = Number;
    //    Debug.Log("AdValueName ==> " + Name);
    //    Debug.Log("AdValueNumber ==> " + Number);
    //    Debug.Log("ContactName ==> " + V_ContactName.text);
    //    Debug.Log("ContactNumber ==> " + V_ContactNumber.text);
    //}
}
