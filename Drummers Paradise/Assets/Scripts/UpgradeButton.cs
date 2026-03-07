using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeIndex;

    public void Purchase()
    {
        UpgradeManager.Instance.BuyUpgrade(upgradeIndex);
    }
}