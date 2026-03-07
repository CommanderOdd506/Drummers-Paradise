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
            ResourceManager.Instance.AddResource("Money", drummerIncome * drummerCount);
            yield return new WaitForSeconds(1f);
        }
    }
}