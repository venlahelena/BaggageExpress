using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CompetitiveGameModeButton : MonoBehaviour
{
    private Button _button;

    [SerializeField]
    private ManagerLevel _ManagerLevel;
    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetNonCasualGameMode);
    }

    private void SetNonCasualGameMode()
    {
        _ManagerLevel.IsCasualGame = false;
        Debug.Log("Non-casual game mode set.");
    }
}
