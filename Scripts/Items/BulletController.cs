using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float power = 100f;

    public float lifeTime = 5f;

    float deltatime = 0f;

    Rigidbody bulletRb;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

        bulletRb.velocity = this.transform.forward * power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
         { 
           Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        deltatime += Time.deltaTime;

        if (deltatime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
  
}
