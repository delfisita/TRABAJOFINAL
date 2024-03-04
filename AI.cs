using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public GameObject Destination1;

    public GameObject Destination2;
    void Start()
    {
        navMeshAgent.destination = Destination1.transform.position;
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position,Destination1.transform.position);

        if(distance < 3)
        {
            navMeshAgent.destination = Destination2.transform.position;
        }
    }
}
