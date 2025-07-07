using UnityEngine;
public class AcceptBag : MonoBehaviour
{
    /*
     * This is just a simple script, attached to an empty GameObject.
     * All it does is detect when the bag collider collides with this.
     * And the mouse drag stops, the bag heads to this object's transform.
    */

    public int beltID;
    public BagItem baggageItem;

    [SerializeField]
    private Transform _baggageSnapPOS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BaggageGrabbed")
        {
            other.transform.position = _baggageSnapPOS.transform.position;
        }
    }
}