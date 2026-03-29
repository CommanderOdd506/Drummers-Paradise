using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeIndex;
    private Upgrade upgrade;
    private Generator generator;
    private Button button;
    public bool isGeneratorButton;

    public Text errorText;
    
    
    private void Start()
    {
        if (isGeneratorButton)
        {
            generator = GeneratorBuyer.Instance.GetGenerator(upgradeIndex);
        }
        else
        {
            upgrade = UpgradeManager.Instance.GetUpgrade(upgradeIndex);
        }
            
        button = GetComponent<Button>();
    }

    
    private void Update()
    {
        if (isGeneratorButton)
        {
            switch (generator.currentState)
            {
                case UpgradeState.Locked:
                    button.interactable = false;
                    break;
                case UpgradeState.Available:
                    button.interactable = true;
                    break;
                case UpgradeState.Purchased:
                    button.interactable = false;
                    break;


            }
        }
        else
        {
            switch (upgrade.currentState)
            {
                case UpgradeState.Locked:
                    button.interactable = false;
                    break;
                case UpgradeState.Available:
                    button.interactable = true;
                    break;
                case UpgradeState.Purchased:
                    button.interactable = false;
                    break;


            }
        }
        
    }

    public void Purchase()              
    {
        if (isGeneratorButton)
        {
            if (!GeneratorBuyer.Instance.BuyGenerator(upgradeIndex, out string error))        //out parameter used to return purchase success + error message
            {
                Debug.Log("Purchase Failed: " + error);
                if (errorText != null)
                {
                    errorText.text = error;
                }
            }
            else
            {
                Debug.Log("Purchase Successful!");

                if (errorText != null)
                {
                    errorText.text = "";
                }
            }
        }
        else
        {
            if (!UpgradeManager.Instance.BuyUpgrade(upgradeIndex, out string error))        //out parameter used to return purchase success + error message
            {
                Debug.Log("Purchase Failed: " + error);
                if (errorText != null)
                {
                    errorText.text = error;
                }
            }
            else
            {
                Debug.Log("Purchase Successful!");

                if (errorText != null)
                {
                    errorText.text = "";
                }
            }
        }
        
    }
}