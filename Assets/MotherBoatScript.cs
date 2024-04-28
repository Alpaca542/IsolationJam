using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBoatScript : MonoBehaviour
{
    GameObject[] myChildren;
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        myChildren = GetComponentsInChildren<GameObject>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
