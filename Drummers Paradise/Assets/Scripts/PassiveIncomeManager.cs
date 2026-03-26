using System.Collections;
using UnityEngine;

public class PassiveIncomeManager : MonoBehaviour
{
    public float drummerIncome = 1f;
    public float followerIncrease;

    void Start()
    {
        StartCoroutine(IncomeLoop());
    }

    //infinite loop for permenant money generation
    IEnumerator IncomeLoop()
    {
        while (true)
        {
            float income = drummerIncome;

            ResourceManager.Instance.AddResource(ResourceType.Money, income);

            ResourceManager.Instance.AddResource(ResourceType.Followers, followerIncrease);

            //Debug.Log("Followers gained: " + followerIncrease);

            yield return new WaitForSeconds(1f);
        }
    }
}