using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public int upgradeIndex;
    private Upgrade upgrade;
    private Button button;

    private void Start()
    {
        upgrade = UpgradeManager.Instance.GetUpgrade(upgradeIndex);
        button = GetComponent<Button>();
    }

    private void Update()
    {
        switch (upgrade.currentState)
        {
            case UpgradeState.Locked:
                button.interactable = false;
                break;
            case UpgradeState.Available:
                button.interactable = true;
                break;
            case UpgradeState.Purchased:
                button.interactable = false;
                break;


        }
    }
    public void Purchase()
    {
        UpgradeManager.Instance.BuyUpgrade(upgradeIndex);
    }
}