using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class Data : MonoBehaviour
{    
    public TMP_InputField fullName;
    public TMP_InputField mobileNumber;

    public TMP_InputField loginUserId;
    public TMP_InputField loginPassword;    

    public GameObject contactPrefab;
    public GameObject parent;  

    [SerializeField] private TMP_Text _userName;

    public ViewDetailPage viewPage;

    [HideInInspector] public bool isValid;
    [HideInInspector] public ContactManager contact;

    GameObject newObject;
    GameObject newContacts;

    private static string Path;

    public AppData appData;
    Contacts newcontact;

    public static Data inst;

    bool isCreating;

    private void Awake()
    {        
        Path = Application.persistentDataPath + "/Data.json";
        inst = this;
    }    

    public void AddRegistrationData(string userId, string password)
    {
        UserData userData = new();
        userData.UserId = userId;
        userData.Password = password;
        userData.contactbook = new();

        appData.users.Add(userData);        
    }

    public void AddContacts(string ContactName, string ContactNumber)
    {
        newcontact = new();
        newcontact.C_UserId = ContactName;
        newcontact.C_Number = ContactNumber;

        UserData validUser = appData.users.Find(u => u.UserId == loginUserId.text);        

        if (validUser != null)
        {
            validUser.contactbook.contactList.Add(newcontact);            
        }

        CreatingContact(ContactName, ContactNumber);
        Debug.Log("Contact Added");        
    }


    private void Start()
    {
        Load();
    }    

    public void Save()
    {
        string path = Path;
        File.WriteAllText(path, JsonUtility.ToJson(appData));

        /*
        BinaryFormatter formatter = new BinaryFormatter();
        string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");
        FileStream stream = new FileStream(path, FileMode.Create);
        AppData data = new AppData();
        formatter.Serialize(stream, data);
        stream.Close();
        */
        Debug.Log("Save: "+JsonUtility.ToJson(appData));
        Debug.Log("Saved");       
    }

    public void Load()
    {
        string path = Path;
        //string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log("Json: "+json);
            appData = JsonUtility.FromJson<AppData>(json);

            /*
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();
            */
            
        }
        else
        {
            Debug.LogError("SaveFile Not Found");            
        }
    }    

    public void LoginValidate()
    {
        Debug.Log("Login Pressed");

        UserData loginUser = appData.users.Find(u => u.UserId == loginUserId.text);        

        if (loginUser != null && loginUser.Password == loginPassword.text)
        {
            _userName.text = loginUser.UserId;
            isValid = true;
            Debug.Log("Valid_User");
            test(loginUser.contactbook.contactList.Count, loginUser);

           // Debug.Log(loginUser.contactbook.contactList.IndexOf(newcontact));
            //Debug.Log(loginUser.contactbook.contactList[1]);
            //Debug.Log(loginUser.contactbook.contactList[2]);
        }
        else
        {
            isValid = false;
            Debug.LogError("Invalid_User");
        }
    }
 
    public void CreatingContact(string ContactName, string ContactNumber)
    {
        Debug.Log("Prefab: "+contactPrefab.transform.position);        
        newObject = Instantiate(contactPrefab, contactPrefab.transform.position, contactPrefab.transform.rotation, parent.transform);        
        contact = newObject.GetComponent<ContactManager>();

        contact.ContactUserId.text = ContactName;
        contact.ContactNumber.text = ContactNumber;
        Debug.Log("newObject: " + newObject.transform.position);
    }

    public void test(int count, UserData loginUser)
    {
        for(int i = 0; i <count; i++)
        {
            Debug.Log("CreateContact ==> " + i);
            newContacts = Instantiate(contactPrefab, contactPrefab.transform.position, contactPrefab.transform.rotation, parent.transform);
            ContactManager displayContacts = newContacts.GetComponent<ContactManager>();
            displayContacts.ContactUserId.text = loginUser.contactbook.contactList[i].C_UserId;
            displayContacts.ContactNumber.text = loginUser.contactbook.contactList[i].C_Number;
        }        
    }

    public void ViewContactDetail(string Name, string Number)
    {
        //viewPage = new();
        viewPage.V_ContactName.text = Name;
        viewPage.V_ContactNumber.text = Number;
    }

    public void test2()
    {
        GameObject[] contacts = GameObject.FindGameObjectsWithTag("Contacts");
        for(int i=0; i<contacts.Length; i++)
        {
            Debug.Log("destroyed"+i);
            Destroy(contacts[i]);
        }
    }
}

[System.Serializable]
public class AppData
{
    public List<UserData> users = new();
}

[System.Serializable]
public class UserData
{
    public string UserId;
    public string Password;

    public ContactBook contactbook = new();      
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