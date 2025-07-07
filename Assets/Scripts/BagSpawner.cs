using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSpawner : MonoBehaviour
{
    public int bagSpawnRate;
    public int levelCompletionInt;

    public int cancelledBagSpawnRate;

    [SerializeField]
    private int _bagSpawnRate;
    [SerializeField]
    private int _levelCompletionInt;

    [SerializeField]
    private float _baggageSpawnRandomEuler;

    [SerializeField]
    private GameObject _placeholderBag;
    [SerializeField]
    private GameObject _cancelledBag;
    [SerializeField]
    private LevelInstanceManager _levelInstanceManager;

    [SerializeField]
    private int _levelStartInt;

    [SerializeField] private EStop _eStop;

    public bool willSpawnCancelledBags;
    //NOTE THIS IS ONLY WHEN THE WEATHER IS BAD

    public bool isSpawningBaggage = true;

    void Start()
    {
        //_bagSpawnRate = Random.Range(3, 6f);
        //_levelCompletionInt = Random.Range(7, 20);
        Invoke("StartDispensing", 0.2f);
        cancelledBagSpawnRate = Random.Range(2, 5);
    }

    private void Update()
    {
         if (_eStop != null && _eStop._isPressed)
        {
            isSpawningBaggage = false;
            return;
        }

        if (isSpawningBaggage == false)
        {
            StopCoroutine(SpawnBaggage());
            Invoke("EStopBagDispense", 3f);
        }
        if (_levelInstanceManager.badWeatherComing == true && willSpawnCancelledBags == false)
        {
            CheckSpawnedCancelledBags();
        }
    }

    private void CheckSpawnedCancelledBags()
    {
        if (!willSpawnCancelledBags)
        {
            Debug.Log("STARTING COROUTINE CANCELLED BAGS!!!!!");
            StartCoroutine(SpawnCancelledBagsCoroutine());
        }
    }

    public IEnumerator SpawnCancelledBagsCoroutine()
    {
        willSpawnCancelledBags = true;
        while (willSpawnCancelledBags == true)
        {
            yield return new WaitForSeconds(cancelledBagSpawnRate);
            Instantiate(_cancelledBag, transform.position, Quaternion.Euler(-90, 0, Random.Range(-80f, 80f)));
        }
    }

    private void EStopBagDispense()
    {
        StartCoroutine(SpawnBaggage());
    }

    private void StartDispensing()
    {
        _bagSpawnRate = bagSpawnRate;
        _levelCompletionInt = levelCompletionInt;

        StartCoroutine(SpawnBaggage());
    }

    public IEnumerator SpawnBaggage()
    {
        while (_levelStartInt < _levelCompletionInt)
        {
            yield return new WaitForSeconds(_bagSpawnRate);
            Instantiate(_placeholderBag, transform.position, Quaternion.Euler(-90, 0,Random.Range(-80f,80f)));
            _levelStartInt++;
        }
    }
}