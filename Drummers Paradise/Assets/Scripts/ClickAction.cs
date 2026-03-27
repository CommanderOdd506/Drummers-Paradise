using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    [Header("Resource Settings")]
    public ResourceType resourceType;
    public float clickValue = 1f;

    public void OnClickHandler()
    {
        ResourceManager.Instance.AddResource(resourceType, clickValue);
    }
    
    public void OnClickMoney()
    {
        ResourceManager.Instance.AddResource(ResourceType.Money, clickValue);
    }

    public void OnClickFollowers()
    {
        ResourceManager.Instance.AddResource(ResourceType.Followers, clickValue);
    }

}
