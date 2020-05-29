using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidObj : MonoBehaviour
{

    // public string typePowerUp;
    public float speed;
    float movement;
    float rotation;

    public AudioSource speaker;
    public AudioClip hitSeffect;

    public GameObject effectExp;

    public void Start()
    {
        movement = -0.8f;
        rotation = 3f;
    }

    public void FixedUpdate()
    {


        transform.Rotate(new Vector3(-rotation, 0, 0));

        transform.Translate(new Vector3(0, 0, movement), Space.World );
        // transform.Translate(new Vector3(0, 0, 0), Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {

        Physics.IgnoreLayerCollision(17, 16);
        Physics.IgnoreLayerCollision(17, 11);

        if (other.gameObject.CompareTag("Bullet"))
        {
            speaker.PlayOneShot(hitSeffect, 1);

            Destroy(other.gameObject);
            Instantiate(effectExp, transform.position, transform.rotation);
            GM.score += 30;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("PowerBullet"))
        {
            speaker.PlayOneShot(hitSeffect, 1);

            Destroy(other.gameObject);
            Instantiate(effectExp, transform.position, transform.rotation);
            GM.score += 30;
            Destroy(gameObject);
        }
    }




}
