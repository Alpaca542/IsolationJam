using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus.Components;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    private NavMeshAgent MyAgent;
    private void Awake()
    {
        MyAgent = GetComponent<NavMeshAgent>();
        MyAgent.updateUpAxis = false;
        MyAgent.updateRotation = false;
    }
    void Update()
    {
        MyAgent.SetDestination(Player.transform.position);
    }
}
