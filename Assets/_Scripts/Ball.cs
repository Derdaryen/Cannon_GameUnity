using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

    public float lifeTime = 4f;
    public GameObject explosion;
    
    public float minY = -20;


  

    void StatusCheck()
    {
         lifeTime -= Time.deltaTime;

        if( lifeTime < 0 )
        {
            Destroy();
        }
        if (transform.position.y < minY)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }

  
}
