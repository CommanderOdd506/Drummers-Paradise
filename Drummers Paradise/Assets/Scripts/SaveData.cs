using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public float money;
    public float followers;

    public List<int> purchasedUpgrades;

    public List<GeneratorSaveData> generators;
}

[Serializable]
public class GeneratorSaveData
{
    public string generatorID;
    public int count;
}