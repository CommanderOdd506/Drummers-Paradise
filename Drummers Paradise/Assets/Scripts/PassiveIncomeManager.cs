using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncomeManager : MonoBehaviour
{
    public static PassiveIncomeManager Instance;

    public float drummerIncome = 1f;
    public float followerIncrease;

    private List<Generator> generators = new List<Generator>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(StartDelay());

        // initial population (optional)
        generators.AddRange(FindObjectsOfType<Generator>());
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(IncomeLoop());
    }
    public void RegisterGenerator(Generator generator)
    {
        if (!generators.Contains(generator))
            generators.Add(generator);
    }

    IEnumerator IncomeLoop()
    {
        while (true)
        {
            ResourceManager.Instance.AddResource(ResourceType.Money, drummerIncome);
            ResourceManager.Instance.AddResource(ResourceType.Followers, followerIncrease);

            foreach (var generator in generators)
            {
                generator.Produce();
            }

            yield return new WaitForSeconds(1f);
        }
    }
} 