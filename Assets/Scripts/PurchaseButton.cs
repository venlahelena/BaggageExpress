using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
    public string productId; // The ID of the product you want to purchase

    private Button button;
    private InAppPurchaseManager purchaseManager;

    private void Start()
    {
        // Get the reference to the Button component
        button = GetComponent<Button>();

        // Get the reference to the InAppPurchaseManager script
        purchaseManager = GetComponent<InAppPurchaseManager>();

        // Add a click listener to the button
        button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        // Remove the click listener to avoid memory leaks
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        // Trigger the purchase flow for the specified product ID
        if (purchaseManager != null)
        {
            purchaseManager.InitiatePurchase(productId);
        }
    }
}
