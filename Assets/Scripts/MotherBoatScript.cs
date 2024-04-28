using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBoatScript : MonoBehaviour
{
    public GameObject[] myChildren;
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool amIMoving = false;
    // Start is called before the first frame update
    void Awake()
    {
        myChildren = GetComponentsInChildren<GameObject>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(amIMoving)
        {
            float dirX = Input.GetAxis("Horizontal");
            float dirY = Input.GetAxis("Vertical");
            foreach (GameObject child in myChildren)
            {
                rb.velocity =new Vector2(dirX * speed, rb.velocity.y);
                child.GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * speed, dirY * speed);

            }
            
        }
    }
}
