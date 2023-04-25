using UnityEngine;
using TMPro;

public class Data : MonoBehaviour
{
    public TMP_InputField userId;
    public TMP_InputField password;
    public TMP_InputField fullName;
    public TMP_InputField mobileNumber;

    public TMP_InputField loginUserId;
    public TMP_InputField loginPassword;

    //public TMP_InputField ContactUserId;
    //public TMP_InputField ContactPassword;

    [SerializeField] private TMP_Text _userName;
    private string _password;

    [HideInInspector] public bool isValid;

    public static Data inst;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        LoadData();
    }

    private void Update()
    {
        Debug.Log("Load User: " + _userName.text);        
        Debug.Log("Load Pass: " + _password);
    }

    public void SaveData()
    {
        SaveSystem.Save(this);
    }

    public void LoadData()
    {
        UserData data = SaveSystem.Load();
        _userName.text = data.UserId;
        _password = data.Password;

    }

    public void Login()
    {
        Debug.Log("Login Pressed");

        if (loginUserId.text == _userName.text && loginPassword.text == _password)
        {
            isValid = true;
            Debug.Log("Valid_User");
        }
        else
        {
            isValid = false;
            Debug.LogError("Invalid_User");
        }
    }
}

[System.Serializable]
public class UserData
{
    public string UserId;
    public string Password;

    public string C_UserId;
    public string C_Password;

    public UserData(Data ContactData)
    {
        UserId = ContactData.userId.text;
        Password = ContactData.password.text;

        //C_UserId = ContactData.ContactuserId.text;
        //C_Password = ContactData.password.text;
    }           
}