using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public float distanceTofollowpath = 2;
    private int i = 0;

    [Header("-----------followPlayer-----------")]

    public bool followplayer;

    private GameObject player;

    private float distancetoplayer;

    public float distancetofollowplayer = 10;
    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position;
        player = FindObjectOfType<PlayerController>().gameObject;
    }


    void Update()
    {
        
        distancetoplayer= Vector3.Distance(transform.position,player.transform.position);
        if(distancetoplayer <=distancetofollowplayer && followplayer)
        {
            FollowPlayer();
        }
        else
        {
            Enemypath();
        }


    }

    public void Enemypath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceTofollowpath)
        {
            if(destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }

    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
