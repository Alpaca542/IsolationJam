using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    public bool IAmFLying = true;
    private NavMeshAgent MyAgent;
    public LayerMask groundlayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MyAgent = GetComponent<NavMeshAgent>();
        MyAgent.updateUpAxis = false;
        MyAgent.updateRotation = false;
    }
    void Update()
    {
        MyAgent.SetDestination(Player.transform.position);
    }
    private void LateUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 5f, groundlayer);
        if (hit && !IAmFLying)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            //transform.position = new Vector2(transform.position.x, hit.point.y+0.5f);
        }
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -transform.right, 0.7f, groundlayer);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, transform.right, 0.7f, groundlayer);
        if (hit2 || hit3)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            CancelInvoke(nameof(NoFlyInvoke));
            Invoke(nameof(NoFlyInvoke), 0.1f);
            if (!IAmFLying)
            {
                rb.AddForce(transform.up * 6000);
            }
            IAmFLying = true;
        }
    }
    public void NoFlyInvoke()
    {
        IAmFLying = false;
    }
}
