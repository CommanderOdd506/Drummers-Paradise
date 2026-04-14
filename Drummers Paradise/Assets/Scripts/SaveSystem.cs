using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    string path;

    void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "save.xml");
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        // ?? Resources
        data.money = ResourceManager.Instance.GetResource(ResourceType.Money);
        data.followers = ResourceManager.Instance.GetResource(ResourceType.Followers);

        // ?? Upgrades

        // ?? Generators

        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(path, FileMode.Create);

        serializer.Serialize(stream, data);
        stream.Close();

        Debug.Log("Game Saved");
    }

    public void LoadGame()
    {
        if (!File.Exists(path))
        {
            Debug.Log("No save file");
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(path, FileMode.Open);

        SaveData data = serializer.Deserialize(stream) as SaveData;
        stream.Close();

        // ?? Load resources
        ResourceManager.Instance.AddResource(ResourceType.Money,
            data.money - ResourceManager.Instance.GetResource(ResourceType.Money));

        ResourceManager.Instance.AddResource(ResourceType.Followers,
            data.followers - ResourceManager.Instance.GetResource(ResourceType.Followers));

        // ?? Load upgrades

        // Load generators

        //find generators check ids 
        //just rebuy already owned generators

        Debug.Log("Game Loaded");
    }

    [ContextMenu("Reset Save")]
    public void ResetSave()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save file deleted!");
        }

        ResourceManager.Instance.SetResource(ResourceType.Money, 0);
        ResourceManager.Instance.SetResource(ResourceType.Followers, 0);

        Debug.Log("Game reset complete");
    }

    void Start()
    {
        LoadGame(); // auto load
    }

    void OnApplicationQuit()
    {
        SaveGame(); // ?? auto save
    }
}