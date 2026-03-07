using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public Dictionary<string, float> resources = new Dictionary<string, float>();
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        resources.Add("Money", 0);
    }

    public void AddResource(string type, float amount)
    {
        if (resources.ContainsKey(type))
        {
            resources[type] += amount;
        }
    }

    public float GetResource(string type)
    {
        return resources.ContainsKey(type) ? resources[type] : 0;
    }

}
