//public static class SaveSystem
//{
//    private const string SAVE_PATH = "/userData.dat";

//    public static void Save(UserData data)
//    {
//        List<UserData> savedData = Load();

//        // Check if the user data already exists in the list
//        UserData existingData = GetUserData(savedData, data.UserId);
//        if (existingData != null)
//        {
//            // Update the existing data
//            existingData.Password = data.Password;
//            // Add other fields to update as needed
//        }
//        else
//        {
//            // Add new user data to the list
//            savedData.Add(data);
//        }

//        BinaryFormatter formatter = new BinaryFormatter();
//        FileStream stream = new FileStream(Application.persistentDataPath + SAVE_PATH, FileMode.Create);
//        formatter.Serialize(stream, savedData);
//        stream.Close();
//    }

//    public static List<UserData> Load()
//    {
//        if (File.Exists(Application.persistentDataPath + SAVE_PATH))
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            FileStream stream = new FileStream(Application.persistentDataPath + SAVE_PATH, FileMode.Open);
//            List<UserData> savedData = formatter.Deserialize(stream) as List<UserData>;
//            stream.Close();
//            return savedData;
//        }
//        else
//        {
//            return new List<UserData>();
//        }
//    }

//    public static UserData GetUserData(List<UserData> savedData, string userId)
//    {
//        return savedData.Find(x => x.UserId == userId);
//    }
//}

//public class Data : MonoBehaviour
//{
//    public TMP_InputField userId;
//    public TMP_InputField password;
//    public TMP_InputField fullName;
//    public TMP_InputField mobileNumber;

//    public TMP_InputField loginUserId;
//    public TMP_InputField loginPassword;

//    [SerializeField] private TMP_Text _userName;
//    private string _password;

//    [HideInInspector] public bool isValid;

//    public static Data inst;

//    private void Awake()
//    {
//        inst = this;
//    }

//    private void Start()
//    {
//        LoadData();
//    }

//    private void Update()
//    {
//        Debug.Log("Load User: " + _userName.text);
//        Debug.Log("Load Pass: " + _password);
//    }

//    public void SaveData()
//    {
//        SaveSystem.Save(new UserData(userId.text, password.text));
//    }

//    public void LoadData()
//    {
//        UserData userData = SaveSystem.GetUserData(SaveSystem.Load(), userId.text);
//        if (userData != null)
//        {
//            _userName.text = userData.UserId;
//            _password = userData.Password;
//        }
//    }

//    public void Login()
//    {
//        Debug.Log("Login Pressed");

//        List<UserData> savedData = SaveSystem.Load();
//        UserData userData = SaveSystem.GetUserData(savedData, loginUserId.text);
//        if (userData != null && userData.Password == loginPassword.text)
//        {
//            isValid = true;
//            Debug.Log("Valid_User");
//        }
//        else
//        {
//            isValid = false;
//            Debug.LogError("Invalid_User");
//        }
//    }
//}

//[System.Serializable]
//public class UserData
//{
//    public string UserId;
//    public string Password;

//    public UserData(string userId, string password)
//    {
//        UserId = userId;
//        Password = password;
//    }
//}
