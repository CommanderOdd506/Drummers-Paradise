using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        button = GetComponent<Button>();

        if (isGeneratorButton)
        {
            generator = GeneratorBuyer.Instance.GetGenerator(upgradeIndex);
        }
        else
        {
            upgrade = UpgradeManager.Instance.GetUpgrade(upgradeIndex);
        }
    }

    /*
    private void OnEnable()
    {
        UpgradeManager.OnUpgradePurchased += RefreshButton;
    }

    private void OnDisable()
    {
        UpgradeManager.OnUpgradePurchased -= RefreshButton;
    }
    */
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

    public void Purchase()              //try-catch exception
    {
        try
        {
            if (isGeneratorButton)
            {
                if (!GeneratorBuyer.Instance.BuyGenerator(upgradeIndex, out string error))
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
            else
            {
                if (!UpgradeManager.Instance.BuyUpgrade(upgradeIndex, out string error))
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
        catch (System.Exception e)
        {
            Debug.LogError("Exception caught in Purchase(): " + e.Message);

            if (errorText != null)
            {
                errorText.text =e.Message;
            }
        }
    }
    /*
    void RefreshButton(Upgrade upgraded)            //event listener
    {
        if (!isGeneratorButton && upgrade == upgraded)
        {
            button.interactable = false;
        }
    }
    */
}