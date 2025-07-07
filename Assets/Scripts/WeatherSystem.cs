using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSystem : MonoBehaviour
{
     public enum WeatherType
    {
        Sunny,
        Cloudy,
        lightSnow,
        lightRain,
        heavySnow,
        heavyRain,
        thunderStorm
    }

    private WeatherType currentWeather;

    public WeatherType GetCurrentWeather()
    {
        return currentWeather;
    }

    public void SetWeatherType(WeatherType weatherType)
    {
        currentWeather = weatherType;

        // Call a method to update the weather effects or perform other actions based on the weather type
        UpdateWeatherEffects();
    }

    private void UpdateWeatherEffects()
    {
        // Update the weather effects based on the currentWeather
        // ...
    }
}