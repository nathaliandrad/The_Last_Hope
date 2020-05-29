using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpecial : MonoBehaviour
{
    public Transform player;
    public int distance;
    public float movementSpeed;
    public AudioSource speaker;
    public AudioClip enemyHitSFX;

    public GameObject bossEfxHit;
    public GameObject explode;

    public GameObject diamond;

    int bossHealth;



    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 250;
        movementSpeed = 20f;
       // diamond.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

      

        if (bossHealth <= 0)
        {
            Instantiate(explode, transform.position, transform.rotation);
            Instantiate(diamond, transform.position, transform.rotation);
            Destroy(gameObject,0.5f);
           
          //  diamond.SetActive(true);
        }

        transform.Translate(new Vector3(0, 0, movementSpeed) * Time.deltaTime);

    }

    public void OnTriggerEnter(Collider other)
    {

        Physics.IgnoreLayerCollision(15, 16);
        Physics.IgnoreLayerCollision(11, 15);
        if (other.gameObject.CompareTag("Bullet"))
        {
              Damage(5);
            speaker.PlayOneShot(enemyHitSFX, 1);
            Instantiate(bossEfxHit, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PowerBullet"))
        {
              Damage(10);
            speaker.PlayOneShot(enemyHitSFX, 1);
            Instantiate(bossEfxHit, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

    }
    public void Damage(int dmg)
    {
        bossHealth -= dmg;
    }

}
