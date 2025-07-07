using UnityEngine;

public class AIrplaneLanding : MonoBehaviour
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
     * This make airplanes go vroom. Purely cosmestic, doesn't affect gameplay.
    */

    void Start()
    {
        _baggageStartTimer = Random.Range(20, 25);
        _moveSpeed = Random.Range(30f, 50f);
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