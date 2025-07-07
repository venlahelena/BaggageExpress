using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggageTractor : MonoBehaviour
{
    [SerializeField]
    private int _baggageStartTimer;
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private bool _isReset;

    [SerializeField]
    private Transform _locDestin;
    [SerializeField]
    private Transform _locInitial;

    /*
     * This make baggagetractor go vroom vroom. More cosmetic shit. Pay no attention to this one.
    */

    void Start()
    {
        _baggageStartTimer = Random.Range(0, 5);
        _moveSpeed = Random.Range(3f, 5f);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _locDestin.position, _moveSpeed * Time.deltaTime);
        if (transform.position == _locDestin.position)
        {
            transform.position = _locInitial.position;
        }
    }
}