using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delay = 3f;

    private void Start()
    {
        Invoke("DestroyObject", delay);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
