using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSounds : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabBagAccept;
    [SerializeField]
    private GameObject _prefabBagReject;

    [SerializeField]
    private GameObject _prefabWinlevel;
    [SerializeField]
    private GameObject _prefabLoseLevel;

    [SerializeField]
    private GameObject _stopWatchTick;

    public void PlayAcceptSound()
    {
        Instantiate(_prefabBagAccept);
    }

    public void PlayRejectSound()
    {
        Instantiate(_prefabBagReject);
    }

    public void PlayLevelWin()
    {
        Instantiate(_prefabWinlevel);
    }

    public void PlayLevelLose()
    {
        Instantiate(_prefabLoseLevel);
    }

    public void PlayStopWatchTick()
    {
        Instantiate(_stopWatchTick);
    }
}