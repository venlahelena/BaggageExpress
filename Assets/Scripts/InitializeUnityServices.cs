using UnityEngine;
using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

public class InitializeUnityServices : MonoBehaviour
{
    public string environment = "production";

    async void Start()
    {
        try
        {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);

            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception)
        {
            Debug.LogError($"An error occurred during services initialization: {exception}");
        }
    }
}