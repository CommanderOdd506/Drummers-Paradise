using System.Collections;
using UnityEngine;

public class PassiveIncomeManager : MonoBehaviour
{
    public float drummerIncome = 1f;
    public int drummerCount = 1;

    void Start()
    {
        StartCoroutine(IncomeLoop());
    }

    //infinite loop for permenant money generation
    IEnumerator IncomeLoop()
    {
        while (true)
        {
            float income = drummerIncome * drummerCount;

            ResourceManager.Instance.AddResource("Money", income);

            int followerGain = Mathf.RoundToInt(income * 0.5f);
            ResourceManager.Instance.AddResource("Followers", followerGain);

            Debug.Log("Followers gained: " + followerGain);

            yield return new WaitForSeconds(1f);
        }
    }
}