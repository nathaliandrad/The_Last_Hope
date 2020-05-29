using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    float timer;
    float secondTimer;
    public GameObject bossBullet;
    public GameObject smallBossBullet;
    public GameObject nozzle;
    public GameObject smallNozzle;
    public GameObject smallNozzle2;
    public GameObject smallNozzle3;
    public GameObject smallNozzle4;

    public float distanceToShoot;

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (timer == 0)
        {
            Shoot();
        }
        timer += 0.2f;
        if (timer > 18)
        {
            timer = 0;
        }

        if (secondTimer == 0)
        {
            SmallBossShoot();
        }
        secondTimer += 0.5f;
        if (secondTimer > 15)
        {
            secondTimer = 0;
        }


    }

    public void Shoot()
    {
        Instantiate(bossBullet, nozzle.transform.position, nozzle.transform.rotation);
       // Instantiate(bossBullet, nozzleRight.transform.position, nozzleRight.transform.rotation);
    }

    public void SmallBossShoot()
    {
        Instantiate(smallBossBullet, smallNozzle.transform.position, smallNozzle.transform.rotation);
        Instantiate(smallBossBullet, smallNozzle2.transform.position, smallNozzle2.transform.rotation);
        Instantiate(smallBossBullet, smallNozzle3.transform.position, smallNozzle3.transform.rotation);
        Instantiate(smallBossBullet, smallNozzle4.transform.position, smallNozzle4.transform.rotation);

    }
}
