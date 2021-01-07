using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 6f;
    public float force = 700f;

    float countdown;
    public GameObject explosionEffect;
    bool hasExploded;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
        
    }


    void Explode()
    {

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearlyObject in colliders )
        {
            Rigidbody rg = nearlyObject.GetComponent<Rigidbody>();
            if (rg != null)
            {
                rg.AddExplosionForce(force, transform.position, radius);
            }
        }

       
        Destroy(gameObject);
        
       
        

    }
}
