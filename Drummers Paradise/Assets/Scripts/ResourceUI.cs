using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    public ResourceType resourceType;

    void Update()
    {
        resourceText.text = resourceType + ": " +
            ResourceManager.Instance.GetResource(resourceType).ToString("F0");
    }
}