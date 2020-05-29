using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float seconds;
    public float speed;

    void Start()
    {
        speed = -6f;
        seconds = 10;
        Destroy(gameObject, seconds);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //shooting into -z direction
         transform.Translate(new Vector3(0, 0, speed));

        // transform.position += transform.forward * -speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreLayerCollision(11, 10);
    }
}
