using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Kits : MonoBehaviour
{
    public enum KitBrands 
    {
        Donner = 20,
        Ludwig = 40,
        DwDrums = 60,
        Tama = 80
    }

    

    public int playerMoney = 0;

    public TMP_Text currentKitText;                     
    
    private Dictionary<KitBrands, UpgradeState> kitStates = new Dictionary<KitBrands, UpgradeState>();

    private KitBrands currentKit;

    void Start()
    {
        foreach ( KitBrands brand in System.Enum.GetValues( typeof( KitBrands ) ) )         //all kits locked 
        {
            kitStates[brand] = UpgradeState.Locked;
        }
        
        UpdateUpgradeStates();
        UpdateKitText();
    }
    void UpdateUpgradeStates()
    {
        foreach (KitBrands brand in System.Enum.GetValues(typeof(KitBrands)))          //automatic unlock states as money grows and player purchases 
        {
            if (kitStates[brand] == UpgradeState.Purchased)
            continue ;

            int price = (int)brand;

            if (playerMoney >= price)
            
                kitStates[brand] = UpgradeState.Available; 
            
            else 
                kitStates[brand] = UpgradeState.Locked;
        }
    }
    
    public void PurchaseUpgrade(KitBrands brand)                    // kit purchasing and player loses money 
    {
        int price = (int)brand;

        if (kitStates[brand] == UpgradeState.Available &&  playerMoney >= price)
        {
            playerMoney -= price;
            kitStates[brand] = UpgradeState.Purchased;

            currentKit = brand;
            
            UpdateKitText();

            Debug.Log(brand + "purchased");
        }
    }

    void UpdateKitText()                                    // on screen kit text to show what kit is selected at the moment
    {
        if (currentKitText != null)
        {
            currentKitText.text = "Current Kit: " + currentKitText.ToString();
        }
    }
}
