using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 3;
    public float randomEnemySpeedFaster = Random.Range(40f, 60f);
    public AudioSource speaker;
    public AudioClip hitSFX;
    public GameObject hitVisualFX;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 15);
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
        Physics.IgnoreLayerCollision(9, 17);

        if (other.CompareTag("Bullet"))
        {
            HandleBulletHit();
        }
        else if (other.CompareTag("PowerBullet"))
        {
            HandlePowerBulletHit();
        }
    }

    void HandleBulletHit()
    {
        speaker.PlayOneShot(hitSFX, 1);
        DestroyBulletAndIncreaseScore(70);
    }

    void HandlePowerBulletHit()
    {
        speaker.PlayOneShot(hitSFX, 1);
        DestroyBulletAndIncreaseScore(300);
    }

    void DestroyBulletAndIncreaseScore(int scoreIncrease)
    {
        DestroyBullet();
        GM.score += scoreIncrease;
    }

    void DestroyBullet()
    {
        Destroy(gameObject, 0.1f);
        enemyHealth = 4;
        Instantiate(hitVisualFX, transform.position, transform.rotation);
    }
}
