using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ContactManager : BaseClass
{
    public TMP_Text ContactUserId;
    public TMP_Text ContactNumber;
    private Button contactButton;
    //public GameObject viewDetailPrefab;

    public static ContactManager inst;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        contactButton = GetComponent<Button>();
        contactButton.onClick.AddListener(ContactButton_OnClick);
    }

    void ContactButton_OnClick()
    {
        Debug.Log("ContactButton Pressed");
        //Data.inst.ultimateTest(ContactUserId.text, ContactNumber.text);
        //ViewDetailPage viewPage = Instantiate(viewDetailPrefab).GetComponent<ViewDetailPage>();
        //viewPage.AddValue(ContactUserId.text, ContactNumber.text);
        Data.inst.ViewContactDetail(ContactUserId.text, ContactNumber.text);
        ScreenManager.instance.showNextScreen(Screen.ViewDetailPage);
    }
}
