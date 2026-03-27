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

    public static System.Action OnResourceChanged;

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
            return;
        }

        resources.Add("Money", 0f);
        resources.Add("Followers", 0f);
    }

    void ModifyResource(ref float resourceValue, float amount)
    {
        resourceValue += amount;
    }

    public void AddResource(ResourceType resourceType, float amount)
    {
        string type = resourceType.ToString();

        if (resources.ContainsKey(type))
        {
            float value = resources[type];
            ModifyResource(ref value, amount);
            resources[type] = value;

           
            OnResourceChanged?.Invoke();
        }
        else
        {
            Debug.LogWarning("Resource Type Not found " + type);
        }
    }

    public float GetResource(ResourceType type)
    {
        string key = type.ToString();
        return resources.ContainsKey(key) ? resources[key] : 0f;
    }
}