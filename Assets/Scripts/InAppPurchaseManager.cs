using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class InAppPurchaseManager : MonoBehaviour, IStoreListener
{
   private ConfigurationBuilder builder;
    private IStoreController storeController;
    private IExtensionProvider storeExtensionProvider;

    void Start()
    {
        // Initialize the builder
        builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add Products depending on whether you have consumables or not. Examples below
        AddProduct("01", ProductType.NonConsumable);
        AddProduct("02", ProductType.NonConsumable);
        // Add more products...

        // Initialize Unity IAP
        InitializePurchasing();

        Debug.Log("Initializing Unity IAP...");
    }

    void AddProduct(string productId, ProductType productType)
    {
        // Create the product and add it to the builder
        builder.AddProduct(productId, productType);

        Debug.Log("Adding product: " + productId + ", Type: " + productType.ToString());

    }

    void InitializePurchasing()
    {
            // Initialize Unity IAP
        if (storeController == null)
        {
            var module = StandardPurchasingModule.Instance();
            ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

            UnityPurchasing.Initialize(this, builder);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        storeExtensionProvider = extensions;

        Debug.Log("Unity IAP initialized successfully.");

    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialization of purchasing failed: " + error);
    }

    [System.Obsolete("Method variant with string parameter is obsolete. Use the variant without the string parameter instead.")]
    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        // Handle the initialization failure here
        Debug.Log("Initialization of purchasing failed: " + error + ", " + message);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // Process the purchase here
        // You can verify the purchase, grant the purchased product, and provide any necessary rewards

        // Example: Grant the purchased product to the user
        Debug.Log("Purchase successful: " + args.purchasedProduct.definition.id);

        // Example: Provide rewards to the user
        if (args.purchasedProduct.definition.id == "01")
        {
            // Grant consumable product
              Debug.Log("Purchase successful: " + args.purchasedProduct.definition.id);
        }
        else if (args.purchasedProduct.definition.id == "02")
        {
            // Grant non-consumable product
              Debug.Log("Purchase successful: " + args.purchasedProduct.definition.id);
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase of product " + product.definition.id + " failed. Reason: " + failureReason);
    }

    // Method to initiate the purchase
    public void InitiatePurchase(string productId)
    {
        if (storeController != null)
        {
            Product product = storeController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("Failed to initiate purchase for product: " + productId);
            }
        }
    }
}
