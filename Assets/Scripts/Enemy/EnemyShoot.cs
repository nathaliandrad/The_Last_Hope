using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float timer;
    public GameObject enemyBullet;
    public GameObject nozzle;
    public GameObject nozzleRight;
    
    public float distanceToShoot;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer == 0)
        {
            Shoot();
        }
        timer += 0.2f;
        if (timer > 30)
        {
            timer = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(enemyBullet, nozzle.transform.position, nozzle.transform.rotation);
        Instantiate(enemyBullet, nozzleRight.transform.position, nozzleRight.transform.rotation);

      
    }

}
