using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public TextMeshProUGUI resourceText;
    public string resourceType = "Money";

    void Update()
    {
        resourceText.text = resourceType + ": " + ResourceManager.Instance.GetResource(resourceType).ToString("F0");
    }


}
