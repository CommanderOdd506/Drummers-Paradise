using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class DrumUpgradeData
{
    public Sprite drumSprite;
    public AudioClip music;
    public int price;
}

public class SpriteMusicUpgrade : MonoBehaviour
{
    public Image drumImage;
    public AudioSource musicSource;

    public DrumUpgradeData[] upgrades;

    public Button upgradeButton;
    public TextMeshProUGUI priceText;

    public CanvasGroup buttonGroup; 

    private int currentLevel = 0;

    void Start()
    {
        ApplyUpgrade();
        UpdateButtonState();

        ResourceManager.OnResourceChanged += UpdateButtonState;
    }

    void OnDestroy()
    {
        ResourceManager.OnResourceChanged -= UpdateButtonState;
    }

    void Update()
    {
        UpdateButtonState();
    }

    public void UpgradeKit()
    {
        if (currentLevel >= upgrades.Length - 1)
            return;

        int cost = upgrades[currentLevel + 1].price;

        float currentMoney = ResourceManager.Instance.GetResource(ResourceType.Money);

        if (currentMoney < cost)
            return;

        ResourceManager.Instance.AddResource(ResourceType.Money, -cost);

        currentLevel++;

        ApplyUpgrade();
        UpdateButtonState();
    }

    void ApplyUpgrade()
    {
        var upgrade = upgrades[currentLevel];

        drumImage.sprite = upgrade.drumSprite;

        if (upgrade.music != null)
        {
            musicSource.clip = upgrade.music;
            musicSource.Play();
        }

        if (currentLevel < upgrades.Length - 1)
        {
            int nextPrice = upgrades[currentLevel + 1].price;
            priceText.text = $"UPGRADE KIT\n{nextPrice}";
        }

    }

    void UpdateButtonState()
    {
        if (currentLevel >= upgrades.Length - 1)
        {
            upgradeButton.interactable = false;

            if (buttonGroup != null)
            {
                buttonGroup.interactable = false;
                buttonGroup.blocksRaycasts = false;
                buttonGroup.alpha = 0.5f;
            }

            return;
        }

        float currentMoney = ResourceManager.Instance.GetResource(ResourceType.Money);
        int nextCost = upgrades[currentLevel + 1].price;

        bool canAfford = currentMoney >= nextCost;

        upgradeButton.interactable = canAfford;

        if (buttonGroup != null)
        {
            buttonGroup.interactable = canAfford;
            buttonGroup.blocksRaycasts = canAfford;
            buttonGroup.alpha = canAfford ? 1f : 0.5f;
        }
    }
}