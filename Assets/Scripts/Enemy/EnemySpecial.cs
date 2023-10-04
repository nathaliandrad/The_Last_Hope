using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpecial : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 20f;
    public AudioSource speaker;
    public AudioClip enemyHitSFX;

    public GameObject bossEfxHit;
    public GameObject explode;
    public GameObject diamond;

    private int bossHealth = 250;

    private void Start()
    {
        // Initialize boss properties
        bossHealth = 250;
    }

    private void FixedUpdate()
    {
        // Check if the boss's health is zero or less
        if (bossHealth <= 0)
        {
            HandleBossDefeat();
        }

        // Move the boss forward
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    private void HandleBossDefeat()
    {
        // Instantiate explosion and diamond
        Instantiate(explode, transform.position, transform.rotation);
        Instantiate(diamond, transform.position, transform.rotation);

        // Destroy the boss
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignore specific collisions
        if (other.CompareTag("Bullet") || other.CompareTag("PowerBullet"))
        {
            HandleBulletCollision(other);
        }
    }

    private void HandleBulletCollision(Collider bullet)
    {
        int damage = bullet.CompareTag("Bullet") ? 5 : 10; // Determine bullet damage
        Damage(damage);

        // Play hit sound and instantiate hit visual effects
        speaker.PlayOneShot(enemyHitSFX, 1);
        Instantiate(bossEfxHit, bullet.transform.position, bullet.transform.rotation);

        // Destroy the bullet
        Destroy(bullet.gameObject);
    }

    private void Damage(int damageAmount)
    {
        bossHealth -= damageAmount;
    }
}
