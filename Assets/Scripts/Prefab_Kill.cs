﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefab_Kill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}