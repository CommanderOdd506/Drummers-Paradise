using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBuyer : MonoBehaviour
{
    public static GeneratorBuyer Instance { get; private set; }

    public Generator[] generators;

    private float currentMoney;

    void Awake()
    {
        Instance = this;
    }
    public Generator GetGenerator(int index)
    {
        Generator generator = generators[index];
        return generator;
    }

    private void Update()
    {
        currentMoney = ResourceManager.Instance.GetResource(ResourceType.Money);

        for (int i = 0; i < generators.Length; i++)
        {
            if (generators[i].currentState == UpgradeState.Purchased)
                return;


            Generator generator = generators[i];

            if (generator.cost > currentMoney)
            {
                generator.currentState = UpgradeState.Locked;
            }
            else
            {
                generator.currentState = UpgradeState.Available;
            }

        }
    }

    //same as upgrade logic but for generators 
    public bool BuyGenerator(int index, out string errorMessage)
    {
        errorMessage = string.Empty;

        Generator generator = generators[index];
        float money = ResourceManager.Instance.GetResource(ResourceType.Money);
        if (generator.currentState == UpgradeState.Purchased)
        {
            errorMessage = "Already Purchased";
            return false;
        }
        if (generator.currentState == UpgradeState.Locked)
        {
            errorMessage = "Upgrade is Locked";
            return false;
        }
        if (money < generator.cost)
        {
            errorMessage = "Not Enough Money";
            return false;
        }
        ResourceManager.Instance.AddResource(ResourceType.Money, -generator.cost);
        generator.currentState = UpgradeState.Purchased;
        UpdateGenerator(generator);
        return true;
    }

    void UpdateGenerator(Generator generator)
    {
        generator.productionCount += generator.productionIncrease;
    }
}
