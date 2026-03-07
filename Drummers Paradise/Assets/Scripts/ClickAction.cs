using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    public float clickValue = 1f;

    public void OnClickDrum()
    {
        ResourceManager.Instance.AddResource("Money", clickValue);
    }
}
