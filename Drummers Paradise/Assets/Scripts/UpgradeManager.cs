using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public List<Upgrade> upgrades = new List<Upgrade>();

    void Awake()
    {
        Instance = this;
    }

    public void BuyUpgrade(int index)
    {
        Upgrade upgrade = upgrades[index];

        float money = ResourceManager.Instance.GetResource("Money");

        if (money >= upgrade.cost)
        {
            ResourceManager.Instance.AddResource("Money", -upgrade.cost);

            ApplyUpgrade(upgrade);
        }

    }

    void ApplyUpgrade(Upgrade upgrade)
    {
        PassiveIncomeManager income = FindObjectOfType<PassiveIncomeManager>();

        if(upgrade.incomeIncrease > 0)
        {
            income.drummerIncome += upgrade.incomeIncrease;
        }

        if (upgrade.drummersToAdd > 0)
        {
            income.drummerCount += upgrade.drummersToAdd;
        }
    }
}

[System.Serializable]
public class Upgrade
{
    public string name;
    public float cost;
    public float incomeIncrease;
    public int drummersToAdd;
}
