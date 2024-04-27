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
        RaycastHit2D hitPlayer = Physics2D.Raycast(Player.transform.position, Vector2.down, 50f, groundlayer);
        RaycastHit2D hitEnemy = Physics2D.Raycast(transform.position, Vector2.down, 50f, groundlayer);
        if ((Mathf.Abs(hitEnemy.point.y - transform.position.y) > 0.5f)&& (Player.transform.position.y < transform.position.y))
        {
            MyAgent.SetDestination(new Vector2(hitEnemy.point.x, hitEnemy.point.y));
        }
        else
        {
            MyAgent.SetDestination(new Vector2(hitPlayer.point.x, hitPlayer.point.y));
        }

    }
    public void NoFlyInvoke()
    {
        IAmFLying = false;
    }
}
