//using UnityEngine;
//using TMPro;
//using System.Collections.Generic;
//using System.IO;

//public class testing : MonoBehaviour
//{
//    public TMP_InputField userId;
//    public TMP_InputField password;
//    public TMP_InputField fullName;
//    public TMP_InputField mobileNumber;

//    public TMP_InputField loginUserId;
//    public TMP_InputField loginPassword;

//    public TMP_InputField ContactName;
//    public TMP_InputField ContactNumber;

//    public GameObject contactPrefab;
//    public GameObject parent;

//    [SerializeField] private TMP_Text _userName;
//    private string _password;

//    [HideInInspector] public bool isValid;
//    [HideInInspector] public ContactManager contact;

//    GameObject newObject;

//    AppData appData;

//    public static Data inst;

//    private void Awake()
//    {
//        appData = new();
//        inst = this;
//    }

//    public void addRegistrationData()
//    {
//        UserData userData = new UserData();
//        userData.UserId = userId.text;
//        userData.Password = password.text;
//        userData.book = new ContactBook();
//        appData.userList.Add(userData);

//        Save();
//    }

//    public void addContacts()
//    {
//        Contacts newContact = new Contacts();
//        newContact.C_UserId = ContactName.text;
//        newContact.C_Number = ContactNumber.text;

//        // Find the user data based on the logged in user
//        UserData currentUser = appData.userList.Find(u => u.UserId == _userName.text);

//        // If the user data was found, add the contact to their contact book
//        if (currentUser != null)
//        {
//            currentUser.book.contactList.Add(newContact);
//            Debug.Log("Contact added: " + newContact.C_UserId);
//            Save();
//        }
//        else
//        {
//            Debug.LogError("Could not find user data for user: " + _userName.text);
//        }
//    }

//    private void Start()
//    {
//        LoadData();
//    }

//    private void Update()
//    {
//        Debug.Log("Load User: " + ContactName.text);
//        Debug.Log("Load Pass: " + ContactNumber.text);
//    }

//    public void Save()
//    {
//        string path = Application.persistentDataPath + "/userData.json";
//        string jsonData = JsonUtility.ToJson(appData);
//        File.WriteAllText(path, jsonData);

//        Debug.Log("Saved");
//        Debug.Log("User: " + _userName.text);
//    }

//    public void LoadData()
//    {
//        string path = Application.persistentDataPath + "/userData.json";

//        if (File.Exists(path))
//        {
//            string jsonData = File.ReadAllText(path);
//            appData = JsonUtility.FromJson<AppData>(jsonData);
//            Debug.Log("Loaded data for " + appData.userList.Count + " users.");
//        }
//        else
//        {
//            Debug.LogWarning("No saved data found at path: " + path);
//        }
//    }

//    public void Login()
//    {
//        Debug.Log("Login Pressed");

//        UserData user = appData.userList.Find(u => u.UserId == loginUserId.text);

//        if (user != null && user.Password == loginPassword.text)
//        {
//            _userName.text = user.UserId;
//            _password = user.Password;
//            isValid = true;
//            Debug.Log("Valid User");
//        }
//        else
//        {
//            isValid = false;
//            Debug.LogError("Invalid User");
//        }
//    }

//    public void CreatingContact()
//    {
//        newObject = Instantiate(contactPrefab, parent.transform);
//        contact = newObject.GetComponent<ContactManager>();
//    }
//}

//[System.Serializable]
//public class AppData
//{
//    public List<UserData> userList = new List<UserData>();
//}

//[System.Serializable]
//public class UserData
//{
//    public string userId;
//    public string password;
//    public ContactBook book = new ContactBook();
//}

//[System.Serializable]
//public class ContactBook
//{
//    public List<Contacts> contactList = new List<Contacts>();
//}

//[System.Serializable]
//public class Contacts
//{
//    public string contactName;
//    public string contactNumber;
//}


