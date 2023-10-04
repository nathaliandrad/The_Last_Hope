using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public int enemy2Health = 5;
    public float randomEnemySpeedFaster = Random.Range(20f, 40f);
    public AudioSource speaker;
    public AudioClip enem2Hit;
    public GameObject hitEfx;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.Translate(Vector3.back * randomEnemySpeedFaster * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other);
    }

    void HandleCollision(Collider other)
    {
        Physics.IgnoreLayerCollision(8, 9);

        if (other.CompareTag("Bullet"))
        {
            HandleBulletHit(1, 50);
        }
        else if (other.CompareTag("PowerBullet"))
        {
            HandleBulletHit(4, 200);
        }
    }

    void HandleBulletHit(int damage, int scoreIncrease)
    {
        speaker.PlayOneShot(enem2Hit, 1);
        Destroy(other.gameObject);
        GM.score += scoreIncrease;
        enemy2Health -= damage;

        if (enemy2Health < 0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        speaker.PlayOneShot(enem2Hit, 1);
        Instantiate(hitEfx, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
        enemy2Health = 5;
    }
}
