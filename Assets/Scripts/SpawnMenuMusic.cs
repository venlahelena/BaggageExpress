using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenuMusic : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuMusic;

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuMusic = GameObject.FindGameObjectWithTag("MusicDestroyer");
        if (!_mainMenuMusic)
        {
            Instantiate(_mainMenuMusic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
