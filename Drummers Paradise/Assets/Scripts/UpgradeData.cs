using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeData
{
    public string name;
    public float cost;
    public float costIncrease;
    public int tier;
    public float multiplier;
    public string resourceType;
}

[Serializable]
public class UpgradeDatabase
{
    public List<UpgradeData> upgrades;
}