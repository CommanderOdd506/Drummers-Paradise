using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumTechGenerator : Generator
{
    public override void Produce()
    {
        ResourceManager.Instance.AddResource(ResourceType.Money, productionCount);
    }
}
