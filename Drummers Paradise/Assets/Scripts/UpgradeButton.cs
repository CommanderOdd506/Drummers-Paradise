using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeIndex;
    //private Upgrade upgrade;
    //private Generator generator;
    private Button button;
    public bool isGeneratorButton;

    public Text errorText;
    
    
    private void Start()
    {
        button = GetComponent<Button>();
    }


    private void Update()
    {
        UpgradeState state;

        if (isGeneratorButton)
        {
            var generator = GeneratorBuyer.Instance.GetGenerator(upgradeIndex);
            state = generator.currentState;
        }
        else
        {
            var upgrade = UpgradeManager.Instance.GetUpgrade(upgradeIndex);
            state = upgrade.currentState;
        }

        button.interactable = (state == UpgradeState.Available);
    }

    public void Purchase()
    {
        bool success;
        string error;

        if (isGeneratorButton)
        {
            success = GeneratorBuyer.Instance.BuyGenerator(upgradeIndex, out error);
        }
        else
        {
            success = UpgradeManager.Instance.BuyUpgrade(upgradeIndex, out error);
        }

        if (!success)
        {
            Debug.Log("Purchase Failed: " + error);

            if (errorText != null)
                errorText.text = error;
        }
        else
        {
            Debug.Log("Purchase Successful!");

            if (errorText != null)
                errorText.text = "";
        }
    }

}