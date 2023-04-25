using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{        
    public static void Save(Data ContactData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/userData.data";

        //string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");

        FileStream stream = new FileStream(path, FileMode.Create);

        UserData data = new UserData(ContactData);

        formatter.Serialize(stream, data);
        stream.Close();        
        Debug.Log("Saved");
        Debug.Log("User: " + data.UserId);
        Debug.Log("Password: " + data.Password);
    }

    public static UserData Load()
    {
        string path = Application.persistentDataPath + "/userData.data";
        //string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            UserData data = formatter.Deserialize(stream) as UserData;

            stream.Close();

            //Debug.Log("Tolo : "+ data.UserId);
            return data;
        }
        else
        {
            Debug.LogError("SaveFile Not Found");
            return null;
        }
    }
}
