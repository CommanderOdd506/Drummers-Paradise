using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = "Money: " + ResourceManager.Instance.GetResource("Money").ToString("F0");
    }


}
