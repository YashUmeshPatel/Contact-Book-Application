using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{        
    public static void Save()
    {
        //BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.dataPath + "/userData.json";

        //string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");

        //FileStream stream = new FileStream(path, FileMode.Create);

        UserData data = new UserData();        

        File.WriteAllText(path, JsonUtility.ToJson(data));

        //formatter.Serialize(stream, data);
        //stream.Close();
        
        Debug.Log("Saved");
        Debug.Log("User: " + data.UserId);
        Debug.Log("Password: " + data.Password);
    }

    public static UserData Load()
    {
        string path = Application.dataPath + "/userData.json";
        //string dataPath = Path.Combine(Application.persistentDataPath, "gameData.dat");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);
            //BinaryFormatter formatter = new BinaryFormatter();

            //FileStream stream = new FileStream(path, FileMode.Open);

            //UserData data = formatter.Deserialize(stream) as UserData;

            //stream.Close();

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
