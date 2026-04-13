using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    public MonoBehaviour purchasableObject; // drag anything that implements IPurchasable
    private IPurchasable purchasable;

    public Text errorText;
    private Button button;

    void Start()
    {
        purchasable = purchasableObject as IPurchasable;
        button = GetComponent<Button>();
    }

    public void Purchase()
    {
        if (!purchasable.CanPurchase(out string error))
        {
            errorText.text = error;
            return;
        }

        purchasable.OnPurchase();
        errorText.text = "";
    }
}