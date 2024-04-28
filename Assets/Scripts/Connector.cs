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
                Instantiate(gameObject.transform.parent.gameObject.GetComponent<elementOfTheBoat>().justLikeMe,new Vector2(transform.position.x+7.3326542f,transform.position.y),Quaternion.identity, collision.gameObject.transform.parent);
            }
            else
            {
                Instantiate(gameObject.transform.parent.gameObject.GetComponent<elementOfTheBoat>().justLikeMe, new Vector2(transform.position.x - 7.3326542f, transform.position.y), Quaternion.identity, collision.gameObject.transform.parent);
            }
        }
    }
}
