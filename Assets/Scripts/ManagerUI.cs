using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ManagerUI : MonoBehaviour
{
    private Scene _sceneName;

    [SerializeField]
    private Image _dollarSignGreen;
    [SerializeField]
    private Image _dollarSignRed;

    //STOP WATCH MASTER
    [SerializeField]
    private Image _stopWatchMaster;

    [SerializeField]
    private GameObject _levelLoseObject;
    [SerializeField]
    private GameObject _resultCanvas;
    [SerializeField]
    private GameObject _hudBar;
    [SerializeField]
    private GameObject _estopText;
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _budHappySprite;
    [SerializeField]
    private GameObject _budMadSprite;
    [SerializeField]
    private GameObject _budMoneySprite;
    [SerializeField]
    private GameObject _stopWatchTickSound;
    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private TextMeshProUGUI _bagsAcceptedRejectedTotal;
    [SerializeField]
    private TextMeshProUGUI _bagsAcceptedPercentage;
    [SerializeField]
    private TextMeshProUGUI _examineScore;
    [SerializeField]
    private TextMeshProUGUI _dollarBalance;
    [SerializeField]
    private TextMeshProUGUI _scoreBalance;
    [SerializeField]
    private TextMeshProUGUI _stopwatchTimer;

    //RESULTS CARD
    [SerializeField]
    private TextMeshProUGUI _bagsAcceptedResultsCard;
    [SerializeField]
    private TextMeshProUGUI _bagsLostResultsCard;
    [SerializeField]
    private TextMeshProUGUI _bagsBalanceResultsCard;
    [SerializeField]
    private TextMeshProUGUI _bagsStarResultsCard;
    [SerializeField]
    private TextMeshProUGUI _bagsScoreResultsCard;

    [SerializeField]
    private LevelInstanceManager levelInstanceManager;

    [SerializeField]
    private WeatherUIManager _weatherUIManager;

    [SerializeField]
    private int _stopwatchint = 10;
    [SerializeField]
    private int _acceptedBagScore;
    [SerializeField]
    private int _rejectedBagScore;
    [SerializeField]
    private int _acceptedAndRejectedBagScoreDecrement;
    [SerializeField]
    private int _acceptedAndRejectedBagScoreIncrement;

    [SerializeField]
    private int _bagsTotalSum = 0;

    [SerializeField]
    private ManagerSounds _soundManager;

    [SerializeField]
    private bool _isCreated;
    [SerializeField]
    private bool _scoreChecked;

    [SerializeField]
    private bool _spawnLoc2Exists;
    [SerializeField]
    private bool _spawnLoc3Exists;
    [SerializeField]
    private bool _spawnLoc4Exists;
    [SerializeField]
    private bool _spawnLoc5Exists;
    [SerializeField]
    private bool _isLevelLost;
    [SerializeField]
    private bool _isStopWatchCoroutineStarted = false;
    [SerializeField]
    private bool _budHappy;
    [SerializeField]
    private bool _budMad;
    [SerializeField]
    private bool _budMoney;
    [SerializeField]
    private bool _spawnLoseSound;

    //Floats
    [SerializeField]
    private float _totalPercentageScore;

    //Arrays
    [SerializeField]
    private int[] _bagsAcceptedRejectedTotalInt;

    private void Awake()
    {
        _sceneName = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        //Get Weather Infromation from WeatherUIManager //
        _weatherUIManager = GetComponent<WeatherUIManager>();

        //Intitlize baggage
        InitializeBaggage();
        Invoke("GetBaggageSumInt", 0.1f);
        Debug.Log("CASSELTON PLAYER PREFS ARE THIS" + (BEPlayerPrefs.casseltonPercentage));
    }

    private void InitializeBaggage()
    {

        _spawnLoc2Exists = GameObject.Find("bagSpawnLoc_2") != null;
        _spawnLoc3Exists = GameObject.Find("bagSpawnLoc_3") != null;
        _spawnLoc4Exists = GameObject.Find("bagSpawnLoc_4") != null;
        _spawnLoc5Exists = GameObject.Find("bagSpawnLoc_5") != null;

        _examineScore.text = "";

        if (_spawnLoc5Exists)
        {
            Debug.Log("Spawn Location 5 exists");
            _spawnLoc3Exists = false;
            _spawnLoc4Exists = false;
            _bagsAcceptedRejectedTotalInt[0] = GameObject.Find("bagSpawnLoc_1").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[1] = GameObject.Find("bagSpawnLoc_2").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[2] = GameObject.Find("bagSpawnLoc_3").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[3] = GameObject.Find("bagSpawnLoc_4").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[4] = GameObject.Find("bagSpawnLoc_5").GetComponent<BagSpawner>().levelCompletionInt;
            BaggageSum(_bagsAcceptedRejectedTotalInt);
        }

        if (_spawnLoc4Exists)
        {
            Debug.Log("Spawn Location 4 exists");
            _spawnLoc3Exists = false;
            _spawnLoc2Exists = false;
            _bagsAcceptedRejectedTotalInt[0] = GameObject.Find("bagSpawnLoc_1").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[1] = GameObject.Find("bagSpawnLoc_2").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[2] = GameObject.Find("bagSpawnLoc_3").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[3] = GameObject.Find("bagSpawnLoc_4").GetComponent<BagSpawner>().levelCompletionInt;
            BaggageSum(_bagsAcceptedRejectedTotalInt);
        }

        if (_spawnLoc3Exists)
        {
            _spawnLoc2Exists = false;
            Debug.Log("Spawn Location 3 exists");
            _bagsAcceptedRejectedTotalInt[0] = GameObject.Find("bagSpawnLoc_1").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[1] = GameObject.Find("bagSpawnLoc_2").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[2] = GameObject.Find("bagSpawnLoc_3").GetComponent<BagSpawner>().levelCompletionInt;
            BaggageSum(_bagsAcceptedRejectedTotalInt);
        }

        if (_spawnLoc2Exists)
        {
            Debug.Log("Spawn Location 2 exists");
            _bagsAcceptedRejectedTotalInt[0] = GameObject.Find("bagSpawnLoc_1").GetComponent<BagSpawner>().levelCompletionInt;
            _bagsAcceptedRejectedTotalInt[1] = GameObject.Find("bagSpawnLoc_2").GetComponent<BagSpawner>().levelCompletionInt;
            BaggageSum(_bagsAcceptedRejectedTotalInt);
        }

        _bagsAcceptedRejectedTotal.text = _bagsTotalSum.ToString();
    }

    private int BaggageSum(int[] _bagsAcceptedRejectedTotalIntLoop)
    {
        foreach (int item in _bagsAcceptedRejectedTotalIntLoop)
        {
            _bagsTotalSum += item;
        }
        return _bagsTotalSum;
        //This gets the total number of spawners * the number of bags spawned per spawner
        //Which is chosen by the ManagerLevel.cs
    }

    private void GetBaggageSumInt()
    {
        //Simply takes the number of rejected and accepted bags and assigns it to a new variable, why? Don't know, don't remember. 
        //This takes it from above. Duh Daniel? idk
        _acceptedAndRejectedBagScoreDecrement = _bagsTotalSum;
    }

    private void DisplayResults()
    {
        //Simply displays the card at the end with the score.
        _resultCanvas.gameObject.SetActive(true);
        _hudBar.gameObject.SetActive(false);
    }

    public void DisplayPauseMenu()
    {
        //Self explanatory
        Time.timeScale = 0.0f;
        _pauseMenu.gameObject.SetActive(true);
    }

    private void Update()
    {
        AddAcceptedBagToScore();
        AddBalanceMoney();

        CheckIfScoreReached();

        DisplayResultsCardVars();

        CalculatePercentageScore();

        UpdateStopwatchDisplay();

        CheckStopwatchTimeout();
    }

    private void CheckIfScoreReached()
    {
        if (_acceptedAndRejectedBagScoreIncrement == _bagsTotalSum)
        {
            _bagsAcceptedPercentage.gameObject.SetActive(true);

            if (!_scoreChecked)
            {
                Invoke("ExamineScore", 0.3f);
                Invoke("DisplayResults", 0.3f);
                _scoreChecked = true;

                if (_sceneName.name == "Level_Casselton")
                {
                    if (_totalPercentageScore > BEPlayerPrefs.casseltonPercentage)
                    {
                        BEPlayerPrefs.casseltonPercentage = _totalPercentageScore;
                        BEPlayerPrefs.SaveBEPlayerPrefs();
                        Debug.Log("PLAYER PREFS SCORE BEATEN!!! SCORE IS NOW" + BEPlayerPrefs.casseltonPercentage);
                    }
                }
            }
        }
    }

    private void DisplayResultsCardVars()
    {
        _totalPercentageScore = ((float)_acceptedBagScore / _bagsTotalSum) * 100;
        _bagsAcceptedPercentage.text = _totalPercentageScore.ToString("F0") + " % ";
        _bagsAcceptedResultsCard.text = _acceptedBagScore.ToString();
        _bagsScoreResultsCard.text = levelInstanceManager.acceptBagRewardScoreCurrent.ToString();
        _bagsLostResultsCard.text = _rejectedBagScore.ToString();
        _bagsBalanceResultsCard.text = "$" + levelInstanceManager.dollarBalanceCurrent.ToString() + ".00";
    }

    private void CalculatePercentageScore()
    {
        _totalPercentageScore = ((float)_acceptedBagScore / _bagsTotalSum) * 100;
        _bagsAcceptedPercentage.text = _totalPercentageScore.ToString("F0") + " % ";
    }

    private void UpdateStopwatchDisplay()
    {
        if (levelInstanceManager.dollarBalanceCurrent < 0)
        {
            _stopWatchMaster.gameObject.SetActive(true);
        }
        else
        {
            _stopWatchMaster.gameObject.SetActive(false);
            _stopwatchint = 10;
        }

        _stopwatchTimer.text = _stopwatchint.ToString();
        CancelDecrementTimer();
    }

    private void CheckStopwatchTimeout()
    {
        if (_stopwatchint < 0)
        {
            _isLevelLost = true;

            if (_isLevelLost)
            {
                StopCoroutine(DecrementTimerEverySecond());

                if (!_spawnLoseSound)
                {
                    _spawnLoseSound = true;
                    Instantiate(_levelLoseObject);
                    Time.timeScale = 0;
                }

                Debug.Log("@@@@@@@@LEVEL LOST, BITCH!!!!!@@@@@");
                _stopWatchMaster.gameObject.SetActive(false);
                _gameOverScreen.SetActive(true);
            }
        }
    }

    /*
     * ALL ESTOP SHIT
    */
    public void DisplayEStopText()
    {
        _estopText.gameObject.SetActive(true);
        Invoke("DisableEStopText", 3f);
    }

    private void DisableEStopText()
    {
        _estopText.gameObject.SetActive(false);
    }

    public void DecrementTimer()
        //Called from LevelInstanceManager.cs if the balance dips below 0
    {
        if (!_isStopWatchCoroutineStarted)
        {
            StartCoroutine(DecrementTimerEverySecond());
        }
    }

    public void CancelDecrementTimer()
    {
        if (levelInstanceManager.dollarBalanceCurrent >= 0)
        {
            //bool to know when to stop calling function
            StopCoroutine(DecrementTimerEverySecond());
            _stopwatchint = 10;
            _isStopWatchCoroutineStarted = false;
        }
    }

    private IEnumerator DecrementTimerEverySecond()
    {
        _isStopWatchCoroutineStarted = true;
        while(levelInstanceManager.balanceisNegative == true && _isLevelLost == false)
        {
            _stopwatchint -= 1;
            Instantiate(_stopWatchTickSound);
            yield return new WaitForSeconds(1.0f);
        }
    }

    /*
 * ALL ESTOP SHIT END***************************
*/

    /*
     * THIS ONLY DISPLAYS THE SCORE SHIT AT THE END WITH THE CARD
     */
    private void ExamineScore()
    {
        if (_totalPercentageScore >= 85 && _totalPercentageScore <= 99)
        {
            _examineScore.text = "4 STAR AIRLINE!";
            Debug.Log("4 Stars!!!!!!");
            _budHappySprite.gameObject.SetActive(true);
            if (_isCreated == false)
            {
                _soundManager.PlayLevelWin();
                _isCreated = true;
            }
        }

        else if (_totalPercentageScore == 100)
        {
            _examineScore.text = "5 STAR AIRLINE!";
            Debug.Log("5 Stars!!!!!!");
            _budMoneySprite.gameObject.SetActive(true);
            if (_isCreated == false)
            {
                _soundManager.PlayLevelWin();
                _isCreated = true;
            }
        }

        else if (_totalPercentageScore >= 70 && _totalPercentageScore <= 84)
        {
            _examineScore.text = "3 STAR AIRLINE";
            Debug.Log("3 Stars!!!!!!");
            _budHappySprite.gameObject.SetActive(true);
            if (_isCreated == false)
            {
                _soundManager.PlayLevelWin();
                _isCreated = true;
            }
        }

        else if (_totalPercentageScore >= 50 && _totalPercentageScore <= 69)
        {
            _examineScore.text = "2 STAR AIRLINE";
            Debug.Log("2 Stars!!!!!!");
            _budMadSprite.gameObject.SetActive(true);
            if (_isCreated == false)
            {
                _soundManager.PlayLevelLose();
                _isCreated = true;
            }
        }
        else if (_totalPercentageScore <= 49)
        {
            _examineScore.text = "1 STAR AIRLINE";
            Debug.Log("1 Star!!!!!!");
            _budMadSprite.gameObject.SetActive(true);
            if (_isCreated == false)
            {
                _soundManager.PlayLevelLose();
                _isCreated = true;
            }
        }
    }

    /*
  * END END CARD SCORE SHIT HERE*******************
  */

    public void UpdateAcceptedBagScore()
    {
        //Dollar Sign
        _dollarSignGreen.gameObject.SetActive(true);
        StartCoroutine(DollarSignGreen());
        //

        _acceptedBagScore++;

        _acceptedAndRejectedBagScoreDecrement--;
        _acceptedAndRejectedBagScoreIncrement++;
        _bagsAcceptedRejectedTotal.text = _acceptedAndRejectedBagScoreDecrement.ToString();

    }

    public void UpdateFailedBagScore()
    {
        _dollarSignRed.gameObject.SetActive(true);
        StartCoroutine(DollarSignRed());

        _rejectedBagScore++;

        _acceptedAndRejectedBagScoreDecrement--;
        _acceptedAndRejectedBagScoreIncrement++;
        _bagsAcceptedRejectedTotal.text = _acceptedAndRejectedBagScoreDecrement.ToString();
    }

    public void AddAcceptedBagToScore()
    {
        _bagsAcceptedRejectedTotal.text = _acceptedAndRejectedBagScoreDecrement.ToString();
        _scoreBalance.text = "$" + _acceptedBagScore.ToString() + ".00";
    }

    public void AddBalanceMoney()
    {
        _dollarBalance.text = "$" + levelInstanceManager.dollarBalanceCurrent.ToString() + ".00";
        _scoreBalance.text = levelInstanceManager.acceptBagRewardScoreCurrent.ToString();
    }

    //Dollar Sign Coroutines
    private IEnumerator DollarSignGreen()
    {
        yield return new WaitForSeconds(0.5f);
        _dollarSignGreen.gameObject.SetActive(false);
    }

    private IEnumerator DollarSignRed()
    {
        yield return new WaitForSeconds(0.5f);
        _dollarSignRed.gameObject.SetActive(false);
    }
}