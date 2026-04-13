using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBuyer : MonoBehaviour, IPurchasable
{
    public float cost;
    public Generator generatorPrefab;

    private Generator spawnedGenerator;

    public float GetCost() => cost;

    public bool CanPurchase(out string error)
    {
        error = "";
        float money = ResourceManager.Instance.GetResource(ResourceType.Money);

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

        spawnedGenerator = Instantiate(generatorPrefab);

        // Register it dynamically
        PassiveIncomeManager.Instance.RegisterGenerator(spawnedGenerator);
    }
}