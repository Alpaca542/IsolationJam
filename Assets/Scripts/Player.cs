using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX*speed,rb.velocity.y );
        if (Mathf.Abs(dirX) > 0.2f)
        {
            if (dirX < 0 && transform.rotation != Quaternion.Euler(0, 180, 0) && transform.rotation != Quaternion.Euler(0, -180, 0))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(dirX > 0 && transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            anim.SetBool("AmIWalking", true);
        }
        else
        {
            anim.SetBool("AmIWalking", false);
        }
    }
}
