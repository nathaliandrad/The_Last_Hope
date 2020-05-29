using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int enemy2Health;
    public float randomEnemySpeedFaster;

    public AudioSource speaker;
    public AudioClip enem2Hit;

    public GameObject hitEfx;

    // Start is called before the first frame update
    void Start()
    {
        randomEnemySpeedFaster = Random.Range(20f, 40f);
        enemy2Health = 5;
        Destroy(gameObject, 30);
        //transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, -randomEnemySpeedFaster) * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {


        Physics.IgnoreLayerCollision(8, 9);

        if (other.CompareTag("Bullet"))
        {
            speaker.PlayOneShot(enem2Hit, 1);
            Destroy(other.gameObject);
            GM.score += 50;
            enemy2Health -= 1;
            if (enemy2Health < 0)
            {
                speaker.PlayOneShot(enem2Hit, 1);
                Instantiate(hitEfx, transform.position, transform.rotation);
                Destroy(gameObject,0.1f);
                enemy2Health = 5;
            }
        }

        if (other.CompareTag("PowerBullet"))
        {
            speaker.PlayOneShot(enem2Hit, 1);
            Destroy(other.gameObject);
            GM.score += 200;
            enemy2Health -= 4;
            if (enemy2Health < 0)
            {
                speaker.PlayOneShot(enem2Hit, 1);
                Instantiate(hitEfx, transform.position, transform.rotation);
                Destroy(gameObject,0.1f);
                enemy2Health = 5;
            }
        }



    }


}
