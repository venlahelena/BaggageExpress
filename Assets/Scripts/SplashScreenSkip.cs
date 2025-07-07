using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenSkip : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitForSplashToEnd());
    }

    private IEnumerator WaitForSplashToEnd()
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("Menu_Main");
    }
}