using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject _fadeOutObject;
    [SerializeField]
    private GameObject _menuClickSoundPrefab;


    public void LoadLevelSelect()
    {
        Instantiate(_menuClickSoundPrefab);
        Invoke("ContinueToLevelSelect", 1f);
    }
    
    public void LoadExtras()
    {
        Instantiate(_menuClickSoundPrefab);
        Invoke("ContinueToExtras", 1f);
    }

    public void ContinueToExtras()
    {
        SceneManager.LoadScene("Menu_Extras");
    }

    public void ContinueToLevelSelect()
    {
        SceneManager.LoadScene("Menu_Level");
    }

    public void LoadMainMenu()
    {
        Instantiate(_fadeOutObject);
        SceneManager.LoadScene("Menu_Main");
    }

     public void LoadLevelMenu()
    {
        Instantiate(_fadeOutObject);
        SceneManager.LoadScene("Level_Map");
    }

    public void Load01Casselton()
    {
        Instantiate(_fadeOutObject);
        SceneManager.LoadScene("Level_Casselton");
    }

     public void LoadDublinMap()
    {
        Instantiate(_fadeOutObject);
        SceneManager.LoadScene("Level_Map_Dublin");
    }

    public void Load10Quigslow()
    {
        Instantiate(_fadeOutObject);
        SceneManager.LoadScene("Level_Quigslow");
    }
}