using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItemCancelled : MonoBehaviour
{
    [SerializeField]
    private ManagerUI _uiManager;
    [SerializeField]
    private ManagerSounds _soundManager;

    Collider _bagCollider;

    [SerializeField]
    private BagDrag _bagDrag;

    [SerializeField]
    private bool _bagScanned;

    [SerializeField]
    private LevelInstanceManager _levelInstanceManager;

    // This script is for the Cancelled Bags are the white bags that will spawn during bad weather. 

    void Start()
    {
        StartCoroutine(BagFailSafe());
        _uiManager = GameObject.Find("LesserManagers").GetComponent<ManagerUI>();
        _soundManager = GameObject.Find("LesserManagers").GetComponent<ManagerSounds>();
        _levelInstanceManager = GameObject.Find("AlmightyLevelManager").GetComponent<LevelInstanceManager>();
        _bagCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AcceptTag")
        {
            _bagCollider.enabled = false;
            if (_bagDrag.hasBeenDragged == true)
            {
                {
                    if (_bagScanned == false)
                    {
                        _bagScanned = true;
                        _bagDrag._isDraggable = false;
                        CancelledBagPenalty();
                    }
                }
            }
        }
    }

    private void CancelledBagPenalty()
    {
        _levelInstanceManager.RejectCancelledBagSubtractMoney();
        _soundManager.PlayRejectSound();
    }

    private IEnumerator BagFailSafe()
    {
        yield return new WaitForSeconds(20.0f);
        Destroy(this.gameObject);
    }
}