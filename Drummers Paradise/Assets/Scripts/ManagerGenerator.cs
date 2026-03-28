using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGenerator : Generator
{
    public float moneyPerSecond;

    public override void Produce()
    {
        ResourceManager.Instance.AddResource(ResourceType.Money, moneyPerSecond);
    }
}
