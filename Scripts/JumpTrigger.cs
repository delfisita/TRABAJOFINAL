using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    PlayerController player;
    void Start()
    {
      player = FindObjectOfType<PlayerController>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor" )
        {
            player.OnGround = true;   
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "floor")
        {
            player.OnGround = false;
        }
    }

}
