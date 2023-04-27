using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ContactManager : BaseClass
{
    public TMP_Text ContactUserId;
    public TMP_Text ContactNumber;
    private Button contactButton;
    //public GameObject viewDetailPrefab;
    

    private void Start()
    {
        contactButton = GetComponent<Button>();
        contactButton.onClick.AddListener(ContactBUtton_OnClick);
    }

    void ContactBUtton_OnClick()
    {
        //ViewDetailPage viewPage = Instantiate(viewDetailPrefab).GetComponent<ViewDetailPage>();
        //viewPage.AddValue(ContactUserId.text, ContactNumber.text);
        Data.inst.ViewContactDetail(ContactUserId.text, ContactNumber.text);
        ScreenManager.instance.showNextScreen(Screen.ViewDetailPage);
    }


}
