using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float seconds;
    public float speed;

    void Start()
    {
        speed = -5f;
        seconds = 5;
        Destroy(gameObject, seconds);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //shooting into -z direction
        transform.Translate(new Vector3(0, speed, 0));

        // transform.position += transform.forward * -speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreLayerCollision(15, 16);
    }
}
