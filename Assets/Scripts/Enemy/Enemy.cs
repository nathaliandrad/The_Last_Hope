using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float randomEnemySpeedFaster;

    public AudioSource speaker;
    public AudioClip hitSFX;

    public GameObject hitVisualFX;
   

    // Start is called before the first frame update
    void Start()
    {
        randomEnemySpeedFaster = Random.Range(40f, 60f);
        enemyHealth = 3;
        Destroy(gameObject, 15);      
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
        Physics.IgnoreLayerCollision(9, 17);

        if (other.CompareTag("Bullet"))
        {
            speaker.PlayOneShot(hitSFX, 1);
           
            Destroy(other.gameObject);
            GM.score += 70;
            enemyHealth -= 1;
            if (enemyHealth < 0)
            {
                speaker.PlayOneShot(hitSFX, 1);
                Instantiate(hitVisualFX, transform.position, transform.rotation);
                Destroy(gameObject,0.1f);
                enemyHealth = 4;
            }
        }
        if (other.CompareTag("PowerBullet"))
        {
            speaker.PlayOneShot(hitSFX, 1);

            Destroy(other.gameObject);
            GM.score += 300;
            enemyHealth -= 3;
            if (enemyHealth < 0)
            {
                speaker.PlayOneShot(hitSFX, 1);
                Instantiate(hitVisualFX, transform.position, transform.rotation);
                Destroy(gameObject, 0.1f);
                enemyHealth = 4;
            }
        }



    }




}
