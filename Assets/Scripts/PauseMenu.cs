using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
        _pauseMenu.gameObject.SetActive(false);
    }

    public void BacktoLevelSelect()
    {
        SceneManager.LoadScene("Menu_Level");
        Time.timeScale = 1.0f;
    }
}
