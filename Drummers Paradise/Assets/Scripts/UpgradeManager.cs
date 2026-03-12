using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public enum UpgradeState
{
    Locked,
    Available,
    Purchased
}
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public List<Upgrade> upgrades = new List<Upgrade>();

    private float currentMoney;
    void Awake()
    {
        Instance = this;
    }

    public Upgrade GetUpgrade(int index)
    {
        Upgrade upgrade = upgrades[index];
        return upgrade;
    }
    public void BuyUpgrade(int index)
    {
        Upgrade upgrade = upgrades[index];

        float money = ResourceManager.Instance.GetResource(ResourceType.Money);

        if (money >= upgrade.cost)
        {
            ResourceManager.Instance.AddResource(ResourceType.Money, -upgrade.cost);

            ApplyUpgrade(upgrade);
        }

    }
    private void Update()
    {
        currentMoney = ResourceManager.Instance.GetResource(ResourceType.Money);

        for (int i = 0; i < upgrades.Count; i++)
        {
            if (upgrades[i].currentState == UpgradeState.Purchased)
                return;


            Upgrade upgrade = upgrades[i];

            if (upgrade.cost > currentMoney)
            {
                upgrade.currentState = UpgradeState.Locked;
            }
            else
            {
                upgrade.currentState = UpgradeState.Available;
            }

        }
    }
    void ApplyUpgrade(Upgrade upgrade)
    {
        PassiveIncomeManager income = FindObjectOfType<PassiveIncomeManager>();

        if(upgrade.upgradeMultiplier.multiplier > 0)
        {
            if (upgrade.upgradeMultiplier.type == ResourceType.Money)
            {
                income.drummerIncome += upgrade.upgradeMultiplier.multiplier;

            }
            else if(upgrade.upgradeMultiplier.type == ResourceType.Followers)
            {
                income.followerIncrease += upgrade.upgradeMultiplier.multiplier;
            }
            
        }
    }
}

[System.Serializable]
public class Upgrade
{
    public string name;
    public UpgradeMultiplier upgradeMultiplier;
    public float cost;
    public float costIncrease;
    public int tier;
    public UpgradeState currentState;
}

[System.Serializable]
public struct UpgradeMultiplier
{
    public float multiplier;
    public ResourceType type;
}
    
