using System.Collections;
using UnityEngine;

public class BagDrag : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private Transform _holdBagPos;

    public bool _isDraggable = false;
    public bool hasBeenDragged = false;
    [SerializeField]
    private float _waitToDrag = 0.5f;

     // Track the drag duration
    public float dragDuration = 0f;

    /*
     * This script just makes the bag follow your mouse cursor so you can drag it into the AcceptBag collider.
     * 
    */

    void Start()
    {
        StartCoroutine(DragTimer());
        rb = GetComponent<Rigidbody>();
        _holdBagPos = GameObject.Find("HoldBagPos").transform;
    }

    private void OnMouseDrag()
    {
        if (_isDraggable == true)
        {
            hasBeenDragged = true;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + _holdBagPos.position.z);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
            rb.isKinematic = true;
            this.gameObject.tag = "BaggageGrabbed";

            // Update the drag duration
            dragDuration += Time.deltaTime;
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    private IEnumerator DragTimer()
    {
        yield return new WaitForSeconds(_waitToDrag);
        _isDraggable = true;
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }
}