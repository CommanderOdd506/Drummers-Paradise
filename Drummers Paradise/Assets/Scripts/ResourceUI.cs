using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    public ResourceType resourceType;

    private void OnEnable()
    {
        ResourceManager.OnResourceChanged += UpdateText;
    }
    private void OnDisable()
    {
        ResourceManager.OnResourceChanged -= UpdateText;
    }
    private void Start()
    {
        UpdateText();
    }
    void UpdateText()
    {
        resourceText.text = resourceType + ": ";
            ResourceManager.Instance.GetResource(resourceType).ToString("F0");
    }
}   