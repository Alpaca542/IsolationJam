using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementOfTheBoat : MonoBehaviour
{
    public bool ConnectedRight = false;
    public bool ConnectedLeft = false;
    public Collider2D rightCollider;
    public Collider2D leftCollider;
    public GameObject justLikeMe;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void ConnectRightSide()
    {
        rightCollider.gameObject.SetActive(false);


    }
    private void ConnectLeftSide()
    {
        leftCollider.gameObject.SetActive(false);
    }
}
