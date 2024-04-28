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
}
