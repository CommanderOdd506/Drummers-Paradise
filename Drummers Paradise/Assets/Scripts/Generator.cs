    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    //base generator class dispalying public fields on children
    public abstract class Generator : MonoBehaviour
    {
        [SerializeField] public float productionCount;
        [SerializeField] public float productionIncrease;
        [SerializeField] public float cost;
        [SerializeField] public ResourceType resourceType;

        public UpgradeState currentState;

        public abstract void Produce();
    }