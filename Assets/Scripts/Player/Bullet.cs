using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 70f;
    public float seconds;

    public Quaternion rot;

    void Start()
    {
  
        seconds = 1.5f;
        Destroy(gameObject, seconds);
       
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, bulletSpeed));

        
    }
    void OnTriggerEnter(Collider other)
    {
        
        //ignore player layer
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(9, 12);

        

    }




}
