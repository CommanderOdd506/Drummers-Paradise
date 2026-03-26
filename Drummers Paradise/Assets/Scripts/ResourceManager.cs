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

        resources.Add("Money", 0f);
        resources.Add("Followers", 0f);
    }

    void ModifyResource(ref float resourceValue, float amount)
    {
        resourceValue += amount;
    }
    public void AddResource(ResourceType resourceType, float amount)      //ref parameter used to modify resource totals in-place inside a helper method
    {
        string type = resourceType.ToString();

        if (resources.ContainsKey(type))
        {
            float value = resources[type];
            ModifyResource(ref value, amount);
            resources[type] = value;
        }
        else
        {
            Debug.LogWarning("Resource Type Not found" + type);
        }
    }

    public float GetResource(ResourceType type)
    {
        string key = type.ToString();
        return resources.ContainsKey(key) ? resources[key] : 0f;
    }
}