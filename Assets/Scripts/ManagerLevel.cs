using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLevel : MonoBehaviour
{

    [SerializeField]
    private ManagerUI _uiManager;

    [SerializeField]
    private bool _isCasualGameType;

    private Scene _sceneName;

    //CONVEYORS///////////////////////////
    [SerializeField]
    private GameObject _baggageConveyor1;
    [SerializeField]
    private GameObject _baggageConveyor2;
    [SerializeField]
    private GameObject _baggageConveyor3;
    [SerializeField]
    private GameObject _baggageConveyor4;
    [SerializeField]
    private GameObject _baggageConveyor5;

    [SerializeField]
    private Conveyor _conveyorScript1;
    [SerializeField]
    private Conveyor _conveyorScript2;
    [SerializeField]
    private Conveyor _conveyorScript3;
    [SerializeField]
    private Conveyor _conveyorScript4;
    [SerializeField]
    private Conveyor _conveyorScript5;
    //////////////////////////////////////

    [SerializeField]
    private LevelInstanceManager _levelInstanceManager;

    [SerializeField]
    private WeatherSystem _weatherSystem;

    //Create accesable variable of IsCasualGame for other classes
     public bool IsCasualGame
    {
        get { return _isCasualGameType; }
        set { _isCasualGameType = value; }
    }

    void Awake()
    {
        //IDENTIFIERS

        _sceneName = SceneManager.GetActiveScene();
        //CAROUSELS
        //This looks for gameobjects with the Conveyor script.
        _conveyorScript1 = _baggageConveyor1.GetComponent<Conveyor>();
        _conveyorScript2 = _baggageConveyor2.GetComponent<Conveyor>();

        // Assign _conveyorScript3 if _baggageConveyor3 is not null
        if (_baggageConveyor3 != null)
        {
            _conveyorScript3 = _baggageConveyor3.GetComponent<Conveyor>();
        }

        CheckLevel();
    }

    void CheckLevel()
    {
        {
            if (_sceneName.name == "Level_Dev")
            {
                Debug.Log("This is the dev level");
                _conveyorScript1.conveyorSpeed = 50.0f;
                _conveyorScript2.conveyorSpeed = 75.0f;

                _levelInstanceManager.dollarBalanceInitial = 250;
                _levelInstanceManager.acceptBagReward = 50;
                _levelInstanceManager.rejectBagReward = 50;

                _levelInstanceManager.acceptBagRewardScore = 75;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 75;

                _levelInstanceManager.baggageLevelCompletionInt = Random.Range(10, 20);
                _levelInstanceManager.baggageSpawnRate = Random.Range(5, 8);
            }
             if (_isCasualGameType == false)
                {
                    _levelInstanceManager.baggageLevelCompletionInt = 46;
                    _levelInstanceManager.baggageSpawnRate = 2;
                }

            if (_sceneName.name == "Level_Casselton")
            {
                Debug.Log("This is the Irish level");
                _conveyorScript1.conveyorSpeed = 100.0f;
                _conveyorScript2.conveyorSpeed = 130.0f;

                _levelInstanceManager.dollarBalanceInitial = 250;
                _levelInstanceManager.acceptBagReward = 50;
                _levelInstanceManager.rejectBagReward = 75;

                _levelInstanceManager.acceptBagRewardScore = 50;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 50;

                _levelInstanceManager.baggageLevelCompletionInt = Random.Range(18, 30);
                _levelInstanceManager.baggageSpawnRate = Random.Range(1, 3);

                if (_isCasualGameType == false)
                {
                    _levelInstanceManager.baggageLevelCompletionInt = 46;
                    _levelInstanceManager.baggageSpawnRate = 2;
                }
            }

            if (_sceneName.name == "Level_Arriba")
            {
                Debug.Log("This is the Mexican level");
                _conveyorScript1.conveyorSpeed = 100.0f;
                _conveyorScript2.conveyorSpeed = 130.0f;

                _levelInstanceManager.dollarBalanceInitial = 250;
                _levelInstanceManager.acceptBagReward = 50;
                _levelInstanceManager.rejectBagReward = 75;

                _levelInstanceManager.acceptBagRewardScore = 75;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 75;

                _levelInstanceManager.baggageLevelCompletionInt = Random.Range(18, 30);
                _levelInstanceManager.baggageSpawnRate = Random.Range(1, 3);

                if (_isCasualGameType == false)
                {
                    _levelInstanceManager.baggageLevelCompletionInt = 51;
                    _levelInstanceManager.baggageSpawnRate = 2;
                }
            }

            if (_sceneName.name == "Level_Brophyville")
            {
                Debug.Log("This is the American level");
                _conveyorScript1.conveyorSpeed = 100.0f;
                _conveyorScript2.conveyorSpeed = 130.0f;

                _levelInstanceManager.dollarBalanceInitial = 250;
                _levelInstanceManager.acceptBagReward = 50;
                _levelInstanceManager.rejectBagReward = 75;

                _levelInstanceManager.acceptBagRewardScore = 75;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 75;

                _levelInstanceManager.baggageLevelCompletionInt = Random.Range(18, 30);
                _levelInstanceManager.baggageSpawnRate = Random.Range(1, 3);

                if (_isCasualGameType == false)
                {
                    _levelInstanceManager.baggageLevelCompletionInt = 59;
                    _levelInstanceManager.baggageSpawnRate = 2;
                }
            }

            if (_sceneName.name == "Level_Quigslow")
            {
                Debug.Log("SOVIET RUSSIA!");
                _conveyorScript1.conveyorSpeed = 100.0f;
                _conveyorScript2.conveyorSpeed = 150.0f;
                _conveyorScript3.conveyorSpeed = 125.0f;

                _levelInstanceManager.dollarBalanceInitial = 200;
                _levelInstanceManager.acceptBagReward = 30;
                _levelInstanceManager.rejectBagReward = 75;

                _levelInstanceManager.acceptBagRewardScore = 100;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 100;

                //Change Weather
                //In terms of level design, we can change the functions
                //This is ideal for "Career" mode where levels are set in stone by us

                if (_isCasualGameType == false)
                {
                    Debug.Log("This is NOT CASUAL, this is also Quigslow");
                    _levelInstanceManager.baggageLevelCompletionInt = 46;
                    _levelInstanceManager.baggageSpawnRate = Random.Range(3, 5);
                }
                else
                {
                    Debug.Log("This IS CASUAL, this is also Quigslow");

                    _levelInstanceManager.baggageLevelCompletionInt = Random.Range(20, 50);
                    _levelInstanceManager.baggageSpawnRate = Random.Range(3, 5);
                }
            }

            if (_sceneName.name == "Level_Millerstein")
            {
                Debug.Log("German Level!");
                _conveyorScript1.conveyorSpeed = 100.0f;
                _conveyorScript2.conveyorSpeed = 100.0f;
                _conveyorScript3.conveyorSpeed = 100.0f;
                _conveyorScript4.conveyorSpeed = 100.0f;


                _levelInstanceManager.dollarBalanceInitial = 200;
                _levelInstanceManager.acceptBagReward = 150;
                _levelInstanceManager.rejectBagReward = 500;

                _levelInstanceManager.acceptBagRewardScore = 100;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 100;

                //Change Weather
                //In terms of level design, we can change the functions
                //This is ideal for "Career" mode where levels are set in stone by us

                if (_isCasualGameType == false)
                {
                    Debug.Log("This is NOT CASUAL, this is also Millerstein.");

                    _levelInstanceManager.baggageLevelCompletionInt = 15;
                    _levelInstanceManager.baggageSpawnRate = Random.Range(4, 5);
                }
                else
                {
                    Debug.Log("This IS CASUAL, this is also Millerstein.");

                    _levelInstanceManager.baggageLevelCompletionInt = Random.Range(20, 50);
                    _levelInstanceManager.baggageSpawnRate = Random.Range(3, 5);
                }
            }

            if (_sceneName.name == "Level_SRC")
            {
                Debug.Log("HARDEST LEVEL!");
                _conveyorScript1.conveyorSpeed = 100.0f;
                _conveyorScript2.conveyorSpeed = 100.0f;
                _conveyorScript3.conveyorSpeed = 100.0f;
                _conveyorScript4.conveyorSpeed = 100.0f;


                _levelInstanceManager.dollarBalanceInitial = 200;
                _levelInstanceManager.acceptBagReward = 150;
                _levelInstanceManager.rejectBagReward = 500;

                _levelInstanceManager.acceptBagRewardScore = 100;
                _levelInstanceManager.acceptBagRewardScoreOriginal = 100;

                //Change Weather
                //In terms of level design, we can change the functions
                //But we are scrapping Casual so this boolean is useless and can be removed?

                if (_isCasualGameType == false)
                {
                    Debug.Log("This is NOT CASUAL, this is also SAINT ROYAL CITY");

                    _levelInstanceManager.baggageLevelCompletionInt = 74;
                    _levelInstanceManager.baggageSpawnRate = Random.Range(4, 5);
                }
                else
                {
                    Debug.Log("This IS CASUAL, this is also SAINT ROYAL CITY!");

                    _levelInstanceManager.baggageLevelCompletionInt = Random.Range(20, 50);
                    _levelInstanceManager.baggageSpawnRate = Random.Range(3, 5);
                }
            }
        }
        // Adjust conveyor speeds based on weather
        AdjustConveyorSpeeds();
        AdjustBagSpawnRate();
    }

    private void AdjustConveyorSpeeds()
    {
        float speedMultiplier = 1.0f; // Default multiplier for conveyor speeds

        // Get the current weather type from the WeatherSystem script
         WeatherSystem.WeatherType currentWeather = _weatherSystem.GetCurrentWeather();

        // Adjust the speed multiplier based on the weather type
        switch (currentWeather)
        {
            case WeatherSystem.WeatherType.Sunny:
                speedMultiplier = 1.0f;
                break;
            case WeatherSystem.WeatherType.Cloudy:
                speedMultiplier = 0.8f;
                break;
            case WeatherSystem.WeatherType.lightSnow:
                speedMultiplier = 0.5f;
                break;
            case WeatherSystem.WeatherType.lightRain:
                speedMultiplier = 0.7f;
                break;
            case WeatherSystem.WeatherType.heavySnow:
                speedMultiplier = 0.3f;
                break;
            case WeatherSystem.WeatherType.heavyRain:
                speedMultiplier = 0.5f;
                break;
            case WeatherSystem.WeatherType.thunderStorm:
                speedMultiplier = 0.5f;
                break;
        }

        // Apply the speed multiplier to each conveyor script if they are not null
        if (_conveyorScript1 != null)
        {
            _conveyorScript1.conveyorSpeed *= speedMultiplier;
        }

        if (_conveyorScript2 != null)
        {
            _conveyorScript2.conveyorSpeed *= speedMultiplier;
        }

        if (_conveyorScript3 != null)
        {
            _conveyorScript3.conveyorSpeed *= speedMultiplier;
        }

        if (_conveyorScript4 != null)
        {
            _conveyorScript4.conveyorSpeed *= speedMultiplier;
        }

        if (_conveyorScript5 != null)
        {
            _conveyorScript5.conveyorSpeed *= speedMultiplier;
        }
    }

    private void AdjustBagSpawnRate()
    {
        // Get the current weather type from the WeatherSystem script
         WeatherSystem.WeatherType currentWeather = _weatherSystem.GetCurrentWeather();

        // Adjust bag spawn rate based on weather
        float spawnRateMultiplier = 1.0f; // Default multiplier for bag spawn rate

        // Adjust the spawn rate multiplier based on the weather type
        switch (currentWeather)
        {
            case WeatherSystem.WeatherType.Sunny:
                spawnRateMultiplier = 1.0f;
                break;
            case WeatherSystem.WeatherType.Cloudy:
                spawnRateMultiplier = 0.8f;
                break;
            case WeatherSystem.WeatherType.lightSnow:
                spawnRateMultiplier = 0.5f;
                break;
            case WeatherSystem.WeatherType.lightRain:
                spawnRateMultiplier = 0.7f;
                break;
            case WeatherSystem.WeatherType.heavySnow:
                spawnRateMultiplier = 0.3f;
                break;
            case WeatherSystem.WeatherType.heavyRain:
                spawnRateMultiplier = 0.5f;
                break;
            case WeatherSystem.WeatherType.thunderStorm:
                spawnRateMultiplier = 0.5f;
                break;
        }

        _levelInstanceManager.baggageSpawnRate = (int)(_levelInstanceManager.baggageSpawnRate * spawnRateMultiplier);
    }
}