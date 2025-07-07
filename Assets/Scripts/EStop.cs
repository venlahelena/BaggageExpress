using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EStop : MonoBehaviour
{
    [SerializeField] private Conveyor[] _conveyorArray;
    [SerializeField] private TextureScroll[] _converyorTextureScroll;
    [SerializeField] private ManagerUI _ui;

    // ESTOP UI OBJECTS
    [SerializeField] private int _eStopInt = 3;
    [SerializeField] private bool _eStopStartedToDecrement;
    [SerializeField] private TextMeshProUGUI _estopIntText;
    [SerializeField] private GameObject _estopUIContainer;
    [SerializeField] private GameObject _estopStopWatchSound;
    [SerializeField] private AudioSource _conveyorAudioSource;
    [SerializeField] private GameObject _prefabEStopAccept;
    [SerializeField] private GameObject _prefabEStopReject;
    [SerializeField] private GameObject[] _estopBars;

    [SerializeField] private int _numberofEStops = 3;
    [SerializeField] private float _originalConveyorSpeed;
    [SerializeField] private float _originalTextureScrollSpeed;
    [SerializeField] public bool _isPressed;
    [SerializeField] private bool _hasCoroutineStarted = false;
    [SerializeField] private bool _isAcceptSoundToPlay;
    [SerializeField] private bool _isRejectSoundToPlay;
    [SerializeField] private bool _eStopCoolDown;

    public bool IsPressed
    {
        get { return _isPressed; }
        set { _isPressed = value; }
    }

    public void TestSpeed()
    {

        //Checks if the EStop has been pressed already
        //If it has, it won't activate
        //If the number of estops is 0, it won't work

        if (_eStopCoolDown == false)
        {
            Invoke("StartEStopCoolDown", 3.0f);
            _eStopCoolDown = true;
            
            if (_numberofEStops > 0)
            {
                _conveyorAudioSource.Stop();
                _estopUIContainer.SetActive(true);
                _eStopStartedToDecrement = true;
                StartCoroutine(_estopDecrement());
                _ui.DisplayEStopText();
                _isPressed = true;
                _numberofEStops--;
                Debug.Log("Successful E-Stop");
            }
            else
            {
                Instantiate(_prefabEStopReject);
                Debug.Log("Out of EStops");
            }
        }
    }

    //Decrements an int by 1 every second 
    //while it starts from 3, this is the stopwatch

    private IEnumerator _estopDecrement()
    {
        if (_eStopStartedToDecrement == true)
        {
            while (_eStopInt > 0)
            {
                yield return new WaitForSeconds(1.0f);
                _eStopInt--;
                Instantiate(_estopStopWatchSound);
                if (_eStopInt == 0)
                {
                    _eStopStartedToDecrement = false;
                    break;
                }
            }
        }
    }

    private void StartEStopCoolDown()
    {
        _eStopCoolDown = false;
    }

    private void Start()
    {
        //textureScroller = GameObject.FindGameObjectsWithTag("ConveyorModels");
    }

    private void Update()
{
    if (!_eStopStartedToDecrement)
    {
        StopCoroutine(_estopDecrement());
        _estopUIContainer.SetActive(false);
        _eStopInt = 3;
    }

    _estopIntText.text = _eStopInt.ToString();

    CheckEStopBarInt();

    if (_numberofEStops >= 0)
    {
        if (_isPressed)
        {
            SetConveyorSpeed(0.0f);
            SetTextureScrollSpeed(0.0f);

            if (!_hasCoroutineStarted)
            {
                StartCoroutine(ReturnToOriginalConveyorSpeed());

                if (!_isAcceptSoundToPlay)
                {
                    PlayEStopAcceptSound();
                    _isAcceptSoundToPlay = true;
                }
            }
        }
        else
        {
            SetConveyorSpeed(_originalConveyorSpeed);
            SetTextureScrollSpeed(_originalTextureScrollSpeed);
        }
    }
    else
    {
        if (_isPressed && !_isRejectSoundToPlay)
        {
            _isRejectSoundToPlay = true;
        }
    }
}

    private void SetConveyorSpeed(float speed)
    {
        foreach (Conveyor conveyors in _conveyorArray)
        {
            conveyors.conveyorSpeed = speed;
        }
    }

    private void SetTextureScrollSpeed(float speed)
    {
        foreach (TextureScroll conveyorTextureScroll in _converyorTextureScroll)
        {
            conveyorTextureScroll.scrollSpeed = speed;
        }
    }   

    private void PlayEStopAcceptSound()
    {
        Instantiate(_prefabEStopAccept);
    }

    private IEnumerator ReturnToOriginalConveyorSpeed()
    {
        _hasCoroutineStarted = true;
        yield return new WaitForSeconds(3.0f);
        _conveyorAudioSource.Play();
        _isAcceptSoundToPlay = false;
        _hasCoroutineStarted = false;
        _isPressed = false;
    }


    private void CheckEStopBarInt()
    {
        if (_numberofEStops == 3)
        {
            _estopBars[2].gameObject.SetActive(true);
            _estopBars[1].gameObject.SetActive(true);
            _estopBars[0].gameObject.SetActive(true);
        }
        else if (_numberofEStops == 2)
        {
            _estopBars[2].gameObject.SetActive(false);
            _estopBars[1].gameObject.SetActive(true);
            _estopBars[0].gameObject.SetActive(true);
        }
        else if (_numberofEStops == 1)
        {
            _estopBars[2].gameObject.SetActive(false);
            _estopBars[1].gameObject.SetActive(false);
            _estopBars[0].gameObject.SetActive(true);
        }
        else
        {
            _estopBars[2].gameObject.SetActive(false);
            _estopBars[1].gameObject.SetActive(false);
            _estopBars[0].gameObject.SetActive(false);
        }
    }
}