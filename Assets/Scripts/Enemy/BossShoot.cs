using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public GameObject bossBullet;
    public GameObject smallBossBullet;
    public GameObject[] nozzles;
    public GameObject[] smallNozzles;
    private float timer = 0f;
    private float secondTimer = 0f;

    public float shootingInterval = 18f;
    public float smallShootingInterval = 15f;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        secondTimer += Time.deltaTime;

        if (timer >= shootingInterval)
        {
            Shoot(bossBullet, nozzles);
            timer = 0f;
        }

        if (secondTimer >= smallShootingInterval)
        {
            Shoot(smallBossBullet, smallNozzles);
            secondTimer = 0f;
        }
    }

    private void Shoot(GameObject bulletPrefab, GameObject[] shootPoints)
    {
        foreach (var nozzle in shootPoints)
        {
            Instantiate(bulletPrefab, nozzle.transform.position, nozzle.transform.rotation);
        }
    }
}
