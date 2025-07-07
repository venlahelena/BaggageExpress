using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float conveyorSpeed;

    //CONVEYOR SPEED IS INHERITED BY MANAGERLEVEL SCRIPT DEPENDING ON SCENE NAME

    private void OnTriggerStay(Collider other)
    {
        float conveyorVelocity = conveyorSpeed * Time.deltaTime;
        Rigidbody bagRigidBody = other.gameObject.GetComponent<Rigidbody>();
        bagRigidBody.velocity = conveyorVelocity * transform.forward;
    }
}