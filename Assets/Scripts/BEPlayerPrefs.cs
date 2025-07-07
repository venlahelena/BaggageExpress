using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEPlayerPrefs : MonoBehaviour
{
    /* This has barely been setup, but apparently PlayerPrefs are needed to store save data and scores, etc.
     */

    public static float playerPrefsGlobalAirlineRating = 1;
    public static int playerPrefsGlobalAirlineBalance = 0;

    //CASSELTON
    public static int casseltonScore;
    public static int casseltonALRating;
    public static float casseltonPercentage = 50.0f;

    public static void SaveBEPlayerPrefs()
    {
        PlayerPrefs.Save();
        Debug.Log("SAVED HIGH SCORE IN PLAYERPEFS!!!");
    }

    //ARRIBA
}