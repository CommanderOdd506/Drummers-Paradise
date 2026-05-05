using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RewardPopup : MonoBehaviour
{
    public GameObject rewardObject;
    public TextMeshProUGUI awardTitleText;
    public TextMeshProUGUI awardDescriptionText;
    public TextMeshProUGUI awardMoneyText;
    private Reward nextReward;

    public Reward[] rewards;
    private int currentRewardIndex = 0;

    void Start()
    {
        nextReward = rewards[currentRewardIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceManager.Instance.GetResource(ResourceType.Followers) > nextReward.followerAmount)
        {
            awardTitleText.text = nextReward.titleText;
            awardDescriptionText.text = nextReward.descriptionText;
            awardMoneyText.text = "+ $" + nextReward.moneyAmount;
            ResourceManager.Instance.AddResource(ResourceType.Money, nextReward.moneyAmount);
            rewardObject.SetActive(true);
            currentRewardIndex++;
            nextReward = rewards[currentRewardIndex];
            
        }
    }
}

[Serializable]
public class Reward
{
    public string titleText;
    public string descriptionText;
    public int moneyAmount;
    public int followerAmount;
}
