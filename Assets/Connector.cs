using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public bool AmIRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Connector"))
        {
            if(AmIRight)
            {

                GameObject WhatTouched = collision.gameObject.transform.parent.gameObject;

            }
        }
    }
}
