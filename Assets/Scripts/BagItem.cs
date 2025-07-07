using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BagItem : MonoBehaviour
{
    public float scoreDecayRate = 0.1f;  // Rate at which the score decays over time
    private float finalScore = 0.0f;
    public float initialScore = 0.0f;

    [SerializeField]
    private int _colorPicker;

    [SerializeField]
    private float _scoreDecayDecrement = 1.0f;

    private float _totalTime;

    [SerializeField]
    private Renderer _rendColor;
    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private ManagerUI _uiManager;
    [SerializeField]
    private ManagerSounds _soundManager;

    [SerializeField]
    private GameObject _baggageBeltThree;
    [SerializeField]
    private GameObject _baggageBeltFour;
    [SerializeField]
    private GameObject _baggageBeltFive;

    [SerializeField]
    private LevelInstanceManager _levelInstanceManager;

    [SerializeField]
    private AcceptBag _acceptBag;

    [SerializeField]
    private bool _bagScanned;
    [SerializeField]
    private bool _twoBelts;
    [SerializeField]
    private bool _threeBelts;
    [SerializeField]
    private bool _fourBelts;

    public bool bagIsBeingDragged;

    [SerializeField]
    private BagDrag _bagDrag;

    Collider _bagCollider;

    private void Awake()
    {
        /*
         * Before the Scenario begins, the game will detect how many belts there are present.
         * The game needs a minimum of two belts to work correctly (duh Daniel >_>). It will search for the tags
         * that are assigned in the editor.
        */

        _baggageBeltThree = GameObject.Find("bagSpawnLoc_3");
        _baggageBeltFour = GameObject.Find("bagSpawnLoc_4");
        _baggageBeltFive = GameObject.Find("bagSpawnLoc_5");

        _meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if (!_baggageBeltThree && !_baggageBeltFour && !_baggageBeltFive)
        {
            _twoBelts = true;
            _threeBelts = false;
            _fourBelts = false;
        }
        if (!_baggageBeltFour && !_baggageBeltFive && _baggageBeltThree)
        {
            _threeBelts = true;
            _twoBelts = false;
            _fourBelts = false;
        }
        if (!_baggageBeltFive && _baggageBeltFour && _baggageBeltThree)
        {
            _fourBelts = true;
            _twoBelts = false;
            _threeBelts = false;
        }

        /*
         * These are controlled simply by booleans. 
        */
    }

    private IEnumerator DecrementDecayScore()
    {
        // Wait for 4 seconds before starting the score decay
        yield return new WaitForSeconds(4f);

        // Calculate the total decay duration based on the score decay rate
        float totalDecayDuration = (_scoreDecayDecrement - 0.5f) / 0.1f * 4f;

        // Get the initial score value
        float initialScoreValue = initialScore;
        Debug.Log("Initial Score: " + initialScoreValue);

        // Retrieve the drag duration from BagDrag script
        float dragDuration = _bagDrag.dragDuration;

        // Calculate the decayed score based on the elapsed time and drag duration
        float elapsedTime = 0f;
        float finalScore = initialScoreValue;

        while (elapsedTime < totalDecayDuration)
        {
            // Calculate the decayed score based on the elapsed time and drag duration
            float decayedScore = Mathf.Lerp(initialScoreValue, 0.5f, elapsedTime / totalDecayDuration) + dragDuration;
            finalScore = decayedScore;
            Debug.Log("Decayed Score: " + decayedScore);

            // Wait for the next frame
            yield return null;

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
        }

        finalScore = 0.5f;
        Debug.Log("Final Score: " + finalScore);
    }

    void Start()
    {

        /*When the bag spawns, it will start theese two timers, one for score increment
         * One for a fail safe taht will remove the bag if it gets lost/unreachable.
         * We talked about fixing this by having the bag count increment and
         * it will respawn eventually.
        */

        StartCoroutine(DecrementDecayScore());
        StartCoroutine(BagFailSafe());


        _uiManager = GameObject.Find("LesserManagers").GetComponent<ManagerUI>();
        _soundManager = GameObject.Find("LesserManagers").GetComponent<ManagerSounds>();
        _levelInstanceManager = GameObject.Find("AlmightyLevelManager").GetComponent<LevelInstanceManager>();
        _bagCollider = GetComponent<BoxCollider>();
        {

            /*
             * This simply assigns the colors of the bags depending on how many belts there are.
             * The color of the belts and bags remain consistent.
            */

            if (_twoBelts == true)
            {
                _colorPicker = Random.Range(0, 2);
                switch (_colorPicker)
                {
                    case 0:
                        _rendColor.material.color = Color.blue;
                        _meshRenderer.materials[1].color = Color.blue;
                        break;
                    case 1:
                        _rendColor.material.color = Color.red;
                        _meshRenderer.materials[1].color = Color.red;
                        break;
                }
            }
            if (_threeBelts == true)
            {
                _colorPicker = Random.Range(0, 3);
                switch (_colorPicker)
                {
                    case 0:
                        _rendColor.material.color = Color.blue;
                        _meshRenderer.materials[1].color = Color.blue;
                        break;
                    case 1:
                        _rendColor.material.color = Color.red;
                        _meshRenderer.materials[1].color = Color.red;
                        break;
                    case 2:
                        _rendColor.material.color = Color.green;
                        _meshRenderer.materials[1].color = Color.green;
                        break;
                }
            }
            if (_fourBelts == true)
            {
                _colorPicker = Random.Range(0, 4);
                switch (_colorPicker)
                {
                    case 0:
                        _rendColor.material.color = Color.blue;
                        _meshRenderer.materials[1].color = Color.blue;
                        break;
                    case 1:
                        _rendColor.material.color = Color.red;
                        _meshRenderer.materials[1].color = Color.red;
                        break;
                    case 2:
                        _rendColor.material.color = Color.green;
                        _meshRenderer.materials[1].color = Color.green;
                        break;
                    case 3:
                        _rendColor.material.color = Color.yellow;
                        _meshRenderer.materials[1].color = Color.yellow;
                        break;
                }
            }
        }
    }

    private void Update()
    {
        //If DecayScore starts to get below 0.5, sets to 0.5, it cannot decrement anymore.
        {
            if (_scoreDecayDecrement <= 0.5)
            {
                _scoreDecayDecrement = 0.5f;
            }
        }
    }

    private IEnumerator BagFailSafe()
    {
        //Destroys the bag object if it's left idle for 20 seconds, see above about changing this
        yield return new WaitForSeconds(20.0f);
        RejectBagTag();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AcceptTag")
        {
            _bagCollider.enabled = false;
            int colorIntCompare = other.gameObject.GetComponent<AcceptBag>().beltID;
            if (_colorPicker == colorIntCompare)
            {
                if (_bagScanned == false)
                {
                    AddAcceptedBagToScore();
                    _bagScanned = true;
                    _bagDrag._isDraggable = false;
                }
            }
            else
            {
                _bagCollider.enabled = false;
                if (_bagScanned == false)
                {
                    RejectBagTag();
                    _bagScanned = true;
                    _bagDrag._isDraggable = false;
                    //Invoke("ReDragBag", 0.001f);
                }
            }
            /*
             * All this chunk of code does is detect when the Bag is colliding with the BagAccept game object
             * It compares the color of the bag against the belt
             * It turns off the mouse drag, it drops down and after 1.5 seconds it gets destroyed
             * off-screen after it is "accepted".
            */
        }
    }

    private void ReDragBag()
    {
        _bagDrag._isDraggable = true;
    }

    public void RejectBagTag()
    {
        _soundManager.PlayRejectSound();
        _uiManager.UpdateFailedBagScore();
        _levelInstanceManager.RejectBagSubtractMoney();

       _totalTime += Time.deltaTime;
    }

    public void AddAcceptedBagToScore()
    {
        _uiManager.UpdateAcceptedBagScore();
        _soundManager.PlayAcceptSound();
        _levelInstanceManager.AcceptBagAndAddMoney(_scoreDecayDecrement);
    }
    
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            HandleBagCollisionWithFloor();
        }
    }
    private void HandleBagCollisionWithFloor()
    {
        // Add your desired logic here when the bag collides with the floor
        // Remove the bag from the scene, add the bag to the number of bags left, etc.

        Debug.Log("Bag collided with the floor!");

        BoxCollider bagCollider = GetComponent<BoxCollider>(); // Use existing BoxCollider reference
        bagCollider.enabled = false; // Disable the bag collider to prevent further collisions
        Destroy(gameObject, 1.5f); // Destroy the bag after 1.5 seconds

        // Increment the number of bags left
        LevelInstanceManager levelInstanceManager = GameObject.Find("AlmightyLevelManager").GetComponent<LevelInstanceManager>();
        if (levelInstanceManager != null)
        {
            levelInstanceManager.bagsLeft++; // Increment the bagsLeft variable
            Debug.Log("Bags left: " + levelInstanceManager.bagsLeft);
        }
    }
}