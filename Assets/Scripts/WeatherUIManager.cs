using UnityEngine;
using UnityEngine.UI;

public class WeatherUIManager : MonoBehaviour
{
    [SerializeField]
    private Image gameStartImage;

    public Sprite sunnySprite;
    public Sprite cloudySprite;
    public Sprite lightSnowSprite;
    public Sprite lightRainSprite;
    public Sprite heavySnowSprite;
    public Sprite heavyRainSprite;
    public Sprite thunderStormSprite;

    public void UpdateWeatherSprite(WeatherSystem.WeatherType weatherType)
    {
        Sprite selectedSprite = null;

        // Determine the appropriate sprite based on the weather type
        switch (weatherType)
        {
            case WeatherSystem.WeatherType.Sunny:
                selectedSprite = sunnySprite;
                break;
            case WeatherSystem.WeatherType.Cloudy:
                selectedSprite = cloudySprite;
                break;
            case WeatherSystem.WeatherType.lightSnow:
                selectedSprite = lightSnowSprite;
                break;
            case WeatherSystem.WeatherType.lightRain:
                selectedSprite = lightRainSprite;
                break;
            case WeatherSystem.WeatherType.heavySnow:
                selectedSprite = heavySnowSprite;
                break;
            case WeatherSystem.WeatherType.heavyRain:
                selectedSprite = heavyRainSprite;
                break;
            case WeatherSystem.WeatherType.thunderStorm:
                selectedSprite = thunderStormSprite;
                break;
        }

        // Update the game start image
        if (gameStartImage != null)
        {
            gameStartImage.sprite = selectedSprite;
        }
    }
}