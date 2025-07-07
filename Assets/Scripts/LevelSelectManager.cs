using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textAirportPercentage;
    [SerializeField]
    private TextMeshProUGUI _textAirportTitleName;
    [SerializeField]
    private TextMeshProUGUI _textAirportHighScore;
    [SerializeField]
    private TextMeshProUGUI _textAirportDifficulty;
    [SerializeField]
    private TextMeshProUGUI _textAirportPenalities;
    [SerializeField]
    private TextMeshProUGUI _textAirportClimate;
    [SerializeField]
    private TextMeshProUGUI _textAirportTraffic;
    [SerializeField]
    private TextMeshProUGUI _textAirportRevenue;

    [SerializeField]
    private GameObject _displayInfoCard;
    [SerializeField]
    private GameObject _displayLeaderboards;
    [SerializeField]
    private GameObject _levelSelectPanel;
    [SerializeField]
    private GameObject _menuClickPrefabSound;

    [SerializeField]
    private Image _flagImage;

    [SerializeField]
    private string _levelSelectionIndex;

    [SerializeField]
    private List<ScrollViewButton> buttons = new List<ScrollViewButton>();

    private Dictionary<Button, LevelData> buttonLevelDataMap = new Dictionary<Button, LevelData>();

    public enum LevelSelector
    {
        Dev,
        Casselton,
        Arriba,
        Brophyville,
        Quigslow,
        SaintRoyalCity,
    }

    [System.Serializable]
    public class ScrollViewButton
    {
        public Button button;
        public LevelData levelData;
    }

    private void Awake()
    {
        foreach (var buttonData in buttons)
        {
            buttonData.button.onClick.AddListener(() => OnButtonClicked(buttonData.levelData));
            buttonLevelDataMap.Add(buttonData.button, buttonData.levelData);
        }
    }

    private void OnButtonClicked(LevelData levelData)
    {
        Instantiate(_menuClickPrefabSound);
        _displayInfoCard.gameObject.SetActive(true);
        _displayLeaderboards.gameObject.SetActive(true);
        _levelSelectPanel.gameObject.SetActive(false);

        UpdateInfoCard(levelData);
    }

    private void UpdateInfoCard(LevelData levelData)
    {
        _textAirportTitleName.text = levelData.levelName;
        _textAirportHighScore.text = levelData.highScore.ToString("F0") + "%";
        _textAirportDifficulty.text = levelData.difficulty.ToString() + "/6";
        _textAirportPenalities.text = levelData.penalties;
        _textAirportClimate.text = levelData.climate;
        _textAirportTraffic.text = levelData.traffic;
        _textAirportRevenue.text = levelData.revenue;
        _levelSelectionIndex = levelData.levelIndex;
        _flagImage.sprite = levelData.flagSprite;
    }

    public void BackToMainMenu()
    {
        Instantiate(_menuClickPrefabSound);
        Invoke("ContinueToMainMenu", 1f);
    }

    public void ContinueToMainMenu()
    {
        SceneManager.LoadScene("Menu_Main");
    }

    public void BackToLevelSelect()
    {
        Instantiate(_menuClickPrefabSound);
        SceneManager.LoadScene("Menu_Level");
    }

    public void ReplayLevel()
    {
        Instantiate(_menuClickPrefabSound);
        Invoke("ContinueReplayLevel", 1f);
    }

    public void LoadLevelMap()
    {
        Instantiate(_menuClickPrefabSound);
        SceneManager.LoadScene("Level_Map_Dublin");
    }

    private void ContinueReplayLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LevelSelectBackButton()
    {
        Instantiate(_menuClickPrefabSound);
        _displayInfoCard.SetActive(false);
        _displayLeaderboards.SetActive(false);
        _levelSelectPanel.gameObject.SetActive(true);
    }

    public void LevelSelectPlayGame()
    {
        Instantiate(_menuClickPrefabSound);
        Invoke("LevelSelectStartGame", 1f);
    }

    public void LevelSelectStartGame()
    {
        SceneManager.LoadScene(_levelSelectionIndex);
    }
}
