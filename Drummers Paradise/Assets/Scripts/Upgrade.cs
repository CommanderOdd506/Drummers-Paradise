using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade : IPurchasable
{
    public string name;
    public UpgradeMultiplier upgradeMultiplier;
    public float cost;
    public float costIncrease;
    public int tier;
    public UpgradeState currentState;

    public float GetCost() => cost;

    public bool CanPurchase(out string error)
    {
        error = "";

        float money = ResourceManager.Instance.GetResource(ResourceType.Money);

        if (currentState == UpgradeState.Purchased)
        {
            error = "Already Purchased";
            return false;
        }

        if (currentState == UpgradeState.Locked)
        {
            error = "Upgrade is Locked";
            return false;
        }

        if (money < cost)
        {
            error = "Not Enough Money";
            return false;
        }

        return true;
    }

    public void OnPurchase()
    {
        ResourceManager.Instance.AddResource(ResourceType.Money, -cost);
        //currentState = UpgradeState.Purchased;

        UpgradeManager.Instance.ApplyUpgrade(this);
    }
}
