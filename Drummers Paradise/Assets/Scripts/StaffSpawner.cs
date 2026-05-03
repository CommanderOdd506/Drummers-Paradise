using UnityEngine;

public class EnableOnPurchase : MonoBehaviour
{
    public GameObject targetObject;

    private bool hasActivated = false;

    public void Activate()
    {
        if (hasActivated)
            return;

        if (targetObject != null)
        {
            targetObject.SetActive(true);
            hasActivated = true;
        }
    }
}