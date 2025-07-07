using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverMenu;

    public void TryLevelAgain()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
        _gameOverMenu.gameObject.SetActive(false);
    }
}
