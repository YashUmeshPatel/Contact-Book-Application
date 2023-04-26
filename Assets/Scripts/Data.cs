using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class Data : MonoBehaviour
{
    public TMP_InputField userId;
    public TMP_InputField password;
    public TMP_InputField fullName;
    public TMP_InputField mobileNumber;

    public TMP_InputField loginUserId;
    public TMP_InputField loginPassword;

    public TMP_InputField ContactName;
    public TMP_InputField ContactNumber;

    public GameObject contactPrefab;
    public GameObject parent;  

    [SerializeField] private TMP_Text _userName;
    private string _password;

    [HideInInspector] public bool isValid;
    [HideInInspector] public ContactManager contact;

    GameObject newObject;

    AppData appData;
    UserData userData;
    ContactBook book;
    Contacts contacts;

    public static Data inst;

    private void Awake()
    {
        contacts = new();
        appData = new();
        book = new();
        userData = new();
        inst = this;
    }    

    public void addRegistrationData()
    {
        userData.UserId = userId.text;
        userData.Password = password.text;

        //Save();
    }

    public void addContacts()
    {
        contacts.C_UserId = ContactName.text;
        contacts.C_Number = ContactNumber.text;

        appData.userList.book.contactList.Add(contacts);

        Debug.Log("Contact ==> "+contacts.C_UserId);
        Save();
    }

    private void Start()
    {
        LoadData();
    }

    private void Update()
    {        
        Debug.Log("Load User: " + ContactName.text);        
        Debug.Log("Load Pass: " + ContactNumber.text);
    }

    public void Save()
    {
        //BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.dataPath + "/userData.json";

        //string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");

        //FileStream stream = new FileStream(path, FileMode.Create);

        //UserData data = new UserData();

        File.WriteAllText(path, JsonUtility.ToJson(userData));

        //formatter.Serialize(stream, data);
        //stream.Close();

        Debug.Log("Saved");
        Debug.Log("User: " + userData.UserId);
        Debug.Log("Password: " + userData.Password);
    }

    public void LoadData()
    {
        UserData data = SaveSystem.Load();
        _userName.text = data.UserId;
        _password = data.Password;

        //contact.ContactUserId.text = data.C_UserId;
        //contact.ContactNumber.text = data.C_Number;
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

    public void CreatingContact()
    {
        Debug.Log("Prefab: "+contactPrefab.transform.position);
        //contactPrefab.transform.position = new Vector3(0, -238.52f, 0);
        newObject = Instantiate(contactPrefab, contactPrefab.transform.position,contactPrefab.transform.rotation,parent.transform);
        //newObject.transform.SetParent(parent.transform);


        contact = newObject.GetComponent<ContactManager>();        
        //newObject.transform.SetParent(parent.transform);
        Debug.Log("newObject: " + newObject.transform.position);
        //newObject.transform.SetLocalPositionAndRotation(new Vector3(0, -238.52f, 0), contactPrefab.transform.rotation);
        //newObject.transform.SetPositionAndRotation(new Vector3(0, -238.52f, 0), contactPrefab.transform.rotation);
        //offset = 252        
    }
}

[System.Serializable]
public class AppData
{
    public UserData userList = new();
}

[System.Serializable]
public class UserData
{
    public string UserId;
    public string Password;

    public ContactBook book = new();

    //ContactBook book = new();

    //public UserData()
    //{
    //    contactList.Add(book);
    //}

    //public UserData(Data ContactData)
    //{
    //    UserId = ContactData.userId.text;
    //    Password = ContactData.password.text;

    //    C_UserId = ContactData.ContactName.text;
    //    C_Number = ContactData.ContactNumber.text;
    //}    
}

[System.Serializable]
public class ContactBook
{
    public List<Contacts> contactList = new();
}

[System.Serializable]
public class Contacts
{
    public string C_UserId;
    public string C_Number;    
}