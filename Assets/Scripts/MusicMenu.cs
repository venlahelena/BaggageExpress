using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicMenu : MonoBehaviour
{
    private static MusicMenu _musicInstance;
    [SerializeField]
    private GameObject _musicDestroyer;

    private void Awake()
    {
        if (!_musicInstance)
        {
            _musicInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        _musicDestroyer = GameObject.FindGameObjectWithTag("MusicDestroyer");
        if (_musicDestroyer)
        {
            Destroy(this.gameObject);
        }
    }
}