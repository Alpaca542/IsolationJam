using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public bool AmIflying = false;
    public float jump = 1;
    public LayerMask groundlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX*speed,rb.velocity.y );
        if(Physics2D.Raycast(transform.position,Vector2.down,30f,groundlayer))
        {
            AmIflying = false;
            
        }
        else
        {
            AmIflying = true;
        }
        Debug.DrawRay(transform.position, Vector2.up,Color.white,10f);
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
        if(Input.GetKeyDown(KeyCode.Space)&&!AmIflying) {
            rb.AddForce(Vector2.up * jump);
        
        }
    }
}
