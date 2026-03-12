using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Money,
    Followers
}

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public Dictionary<string, float> resources = new Dictionary<string, float>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        resources.Add("Money", 0);
        resources.Add("Followers", 0);
    }

    public void AddResource(ResourceType resourceType, float amount)
    {
        string type = resourceType.ToString();

        if (resources.ContainsKey(type))
        {
            resources[type] += amount;
        }
    }

    public float GetResource(ResourceType type)
    {
        string key = type.ToString();
        return resources.ContainsKey(key) ? resources[key] : 0f;
    }
}