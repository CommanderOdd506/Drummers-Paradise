using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUIBinder : MonoBehaviour
{
    public List<TextMeshProUGUI> upgradeTexts;

    void Start()
    {
        for (int i = 0; i < UpgradeManager.Instance.upgrades.Count; i++)
        {
            Upgrade upgrade = UpgradeManager.Instance.upgrades[i];

            if (i < upgradeTexts.Count)
            {
                upgrade.SetText(upgradeTexts[i]);
            }
        }
    }
}