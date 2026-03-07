using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> upgrades = new List<Upgrade>();
}

[System.Serializable]
public class Upgrade
{
    public string name;
    public float cost;
    public float incomeIncrease;
}
