using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using TMPro;
using System.IO;

public enum UpgradeState
{
    Locked,
    Available,
    Purchased
}
public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public static System.Action<Upgrade> OnUpgradePurchased;                //delegate event 

    public List<Upgrade> upgrades = new List<Upgrade>();

    private float currentMoney;
    void Awake()
    {
        Instance = this;
        LoadUpgradesFromFile();
    }

    public Upgrade GetUpgrade(int index)
    {
        Upgrade upgrade = upgrades[index];
        return upgrade;
    }
    public bool BuyUpgrade(int index, out string errorMessage)      //out parameter used to return purchase success + error message
    {
        errorMessage = "";

        Upgrade upgrade = upgrades[index];
        
        float money = ResourceManager.Instance.GetResource(ResourceType.Money);

        if(upgrade.currentState == UpgradeState.Purchased)
        {
            errorMessage = "Already Purchased";
            return false;
        }
        if(upgrade.currentState == UpgradeState.Locked)
        {
            errorMessage = "Upgrade is Locked";
            return false;
        }
        if (money < upgrade.cost)
        {
            errorMessage = "Not Enough Money";
            return false;
        }
        ResourceManager.Instance.AddResource(ResourceType.Money, -upgrade.cost);
        //upgrade.currentState = UpgradeState.Purchased;
        ApplyUpgrade(upgrade);
        OnUpgradePurchased?.Invoke(upgrade);                                         //fires the event
        return true;
    }
    private void Update()
    {
        currentMoney = ResourceManager.Instance.GetResource(ResourceType.Money);

        for (int i = 0; i < upgrades.Count; i++)
        {
            if (upgrades[i].currentState == UpgradeState.Purchased)
                continue;


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
    public void ApplyUpgrade(Upgrade upgrade)
    {
        PassiveIncomeManager income = FindObjectOfType<PassiveIncomeManager>();
        upgrade.cost *= upgrade.costIncrease;
        upgrade.text.text = upgrade.cost.ToString();
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
    void LoadUpgradesFromFile()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "upgrades.json");

        if (!File.Exists(path))
        {
            Debug.LogError("Upgrades JSON not found!");
            return;
        }

        string json = File.ReadAllText(path);

        UpgradeDatabase db = JsonUtility.FromJson<UpgradeDatabase>(json);

        upgrades.Clear();

        foreach (var data in db.upgrades)
        {
            upgrades.Add(UpgradeFactory.Create(data));
        }

        Debug.Log("Loaded upgrades: " + upgrades.Count);
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
    public TextMeshProUGUI text;

    public void SetText(TextMeshProUGUI textMesh)
    {
        text = textMesh;
    }
}

[System.Serializable]
public struct UpgradeMultiplier
{
    public float multiplier;
    public ResourceType type;
}
    
