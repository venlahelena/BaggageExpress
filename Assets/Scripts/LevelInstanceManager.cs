using UnityEngine;

public class LevelInstanceManager : MonoBehaviour
{
    // Public Variables
    public int dollarBalanceInitial;
    public int dollarBalanceCurrent;
    public int baggageSpawnRate;
    public int baggageLevelCompletionInt;
    public int acceptBagReward;
    public int rejectBagReward;
    public int acceptBagRewardScore;
    public int acceptBagRewardScoreOriginal;
    public int acceptBagRewardScoreCurrent;
    public bool badWeatherComing = false;
    public bool balanceisNegative;
     public int bagsLeft;

    // Serialized Private Variables
    [SerializeField] private int _badWeatherCancelledBagRate;
    [SerializeField] private int _freePlayBaggageSpawnRate; // New variable for FreePlay mode
    [SerializeField] private int _baggageSpawnRate;
    [SerializeField] private int _baggageLevelCompletionInt;
    [SerializeField] private bool _hasCoroutineBeenCalled = false;

    // [SerializeField] private bool dispenseCancelledBags = false;

    [SerializeField] private GameObject _bagSpawnerGameObjectOne;
    [SerializeField] private GameObject _bagSpawnerGameObjectTwo;
    [SerializeField] private GameObject _bagSpawnerGameObjectThree;
    [SerializeField] private GameObject _bagSpawnerGameObjectFour;
    [SerializeField] private GameObject _bagSpawnerGameObjectFive;
    [SerializeField] private ManagerLevel _managerLevel;

    [SerializeField] private float _baggageSpawnRateModifier;
    [SerializeField] private float _conveyorSpeedModifier;

    // Private Variables
    private BagSpawner _bagSpawnerOne;
    private BagSpawner _bagSpawnerTwo;
    private BagSpawner _bagSpawnerThree;
    private BagSpawner _bagSpawnerFour;
    private BagSpawner _bagSpawnerFive;

    [SerializeField] private WeatherSystem _weatherSystem;
    [SerializeField] private WeatherUIManager _weatherUIManager;
    [SerializeField] private WeatherSystem.WeatherType _desiredWeather;

    void Start()
    {
        _badWeatherCancelledBagRate = Random.Range(0, 4);
        _baggageLevelCompletionInt = baggageLevelCompletionInt;
        _baggageSpawnRate = baggageSpawnRate;

        InitializeBagSpawners();
        UpdateBagSpawnerRates();

        _weatherSystem.SetWeatherType(_desiredWeather);
        _weatherUIManager.UpdateWeatherSprite(_desiredWeather);

        if (_managerLevel.IsCasualGame)
        {
            SetFreePlayBaggageSpawnRate();
        }
        else
        {
            SetRegularBaggageSpawnRate();
        }

        DestroyUIAfterDelay();
    }

    private void Update()
    {
        CheckNegativeBalance();
        SpawnCancelledBags();
    }

      public void SetWeatherType(WeatherSystem.WeatherType weatherType)
    {
        _weatherSystem.SetWeatherType(weatherType);
        _weatherUIManager.UpdateWeatherSprite(weatherType);
        _desiredWeather = weatherType;
    }

    public void SetWeatherEffects(float spawnRateModifier, float conveyorSpeedModifier)
    {
        _baggageSpawnRateModifier = spawnRateModifier;
        _conveyorSpeedModifier = conveyorSpeedModifier;

        UpdateBagSpawnerRatesWithWeather();
    }
    private void DestroyUIAfterDelay()
    {
        // Find the UI/GameObjects you want to destroy
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("DestroyAfterDelay");

        // Loop through the objects and attach the DestroyAfterDelay script
        foreach (GameObject obj in objectsToDestroy)
        {
            DestroyAfterDelay destroyScript = obj.AddComponent<DestroyAfterDelay>();
            destroyScript.delay = 3f; // Set the delay to 3 seconds
        }
    }

    // Updates the bag spawner rates by applying the spawn rate modifier.
    void UpdateBagSpawnerRatesWithWeather()
{
    if (_bagSpawnerOne != null)
        _bagSpawnerOne.bagSpawnRate = (int)(_baggageSpawnRate * _baggageSpawnRateModifier);

    if (_bagSpawnerTwo != null)
        _bagSpawnerTwo.bagSpawnRate = (int)(_baggageSpawnRate * _baggageSpawnRateModifier);

    if (_bagSpawnerThree != null)
        _bagSpawnerThree.bagSpawnRate = (int)(_baggageSpawnRate * _baggageSpawnRateModifier);

    if (_bagSpawnerFour != null)
        _bagSpawnerFour.bagSpawnRate = (int)(_baggageSpawnRate * _baggageSpawnRateModifier);
}

    // Initializes bag spawners by getting the components and assigning them to private variables.
    void InitializeBagSpawners()
    {
        _bagSpawnerOne = _bagSpawnerGameObjectOne.GetComponent<BagSpawner>();
        _bagSpawnerTwo = _bagSpawnerGameObjectTwo.GetComponent<BagSpawner>();

        if (_bagSpawnerGameObjectThree != null)
        {
            _bagSpawnerThree = _bagSpawnerGameObjectThree.GetComponent<BagSpawner>();
        }
        else
        {
            Debug.Log("Level Instance Manager sez NO THREE 3!!!!!!!!!!!!!!!");
        }

        if (_bagSpawnerGameObjectFour != null)
        {
            _bagSpawnerFour = _bagSpawnerGameObjectFour.GetComponent<BagSpawner>();
        }
        else
        {
            Debug.Log("Level Instance Manager sez NO FOUR 4!!!!!!!!!!!!!!!");
        }
    }

    // Updates the bag spawner rates by assigning the current values to the bag spawners.
    void UpdateBagSpawnerRates()
    {
        _bagSpawnerOne.bagSpawnRate = _baggageSpawnRate;
        _bagSpawnerOne.levelCompletionInt = _baggageLevelCompletionInt;

        _bagSpawnerTwo.bagSpawnRate = _baggageSpawnRate;
        _bagSpawnerTwo.levelCompletionInt += _baggageLevelCompletionInt;

        if (_bagSpawnerThree != null)
        {
            _bagSpawnerThree.bagSpawnRate = _baggageSpawnRate;
            _bagSpawnerThree.levelCompletionInt += _baggageLevelCompletionInt;
        }

        if (_bagSpawnerFour != null)
        {
            _bagSpawnerFour.bagSpawnRate = _baggageSpawnRate;
            _bagSpawnerFour.levelCompletionInt += _baggageLevelCompletionInt;
        }
    }

    // Sets the baggage spawn rate for free play mode.
    void SetFreePlayBaggageSpawnRate()
    {
        _baggageSpawnRate = _freePlayBaggageSpawnRate;
    }

    // Sets the baggage spawn rate for regular mode.
    void SetRegularBaggageSpawnRate()
    {
        _baggageSpawnRate = baggageSpawnRate;
    }

    // Spawns cancelled bags if bad weather is coming.
    private void SpawnCancelledBags()
    {
        if (badWeatherComing == true)
        {
            _bagSpawnerOne.willSpawnCancelledBags = true;
        }
    }

    // Checks if the current dollar balance is negative and handles UI and timer decrement accordingly.
    private void CheckNegativeBalance()
    {
        // GET UI MANAGER
        ManagerUI _uiManager = GameObject.FindWithTag("LesserManager").GetComponent<ManagerUI>();
        if (dollarBalanceCurrent < 0)
        {
            balanceisNegative = true;
            if (balanceisNegative == true)
            {
                _hasCoroutineBeenCalled = true;
                if (_hasCoroutineBeenCalled == true)
                {
                    _hasCoroutineBeenCalled = false;
                    _uiManager.DecrementTimer();
                }
            }
        }
        if (dollarBalanceCurrent >= 0)
        {
            balanceisNegative = false;
            _uiManager.CancelDecrementTimer();
        }
    }

    // Adds money and score when a bag is accepted.
    public void AcceptBagAndAddMoney(float decayScore)
    {
        // Dollar Score
        dollarBalanceCurrent += acceptBagReward;

        // Score
        int acceptBagRounded = (int)(acceptBagRewardScore * decayScore);
        Debug.Log("Accepted bag ROUNDED SCORE is: + " + acceptBagRounded);
        acceptBagRewardScoreCurrent += acceptBagRounded;
        acceptBagRewardScore = acceptBagRewardScoreOriginal;
    }

    // Subtracts money when a bag is rejected.
    public void RejectBagSubtractMoney()
    {
        dollarBalanceCurrent -= rejectBagReward;
    }

    // Subtracts money when a cancelled bag is rejected.
    public void RejectCancelledBagSubtractMoney()
    {
        dollarBalanceCurrent -= rejectBagReward * 3;
    }
}