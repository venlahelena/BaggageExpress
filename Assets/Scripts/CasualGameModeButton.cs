using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CasualGameModeButton : MonoBehaviour
{
    private Button _button;
    
    [SerializeField]
    private ManagerLevel _ManagerLevel;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetCasualGameMode);
    }

    private void SetCasualGameMode()
    {
        _ManagerLevel.IsCasualGame = true;
        Debug.Log("Casual game mode set.");
    }
}
