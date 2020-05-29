using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickUpManager : MonoBehaviour
{
    public GameObject powerUpGun;
    public GameObject points;
    public GameObject health;
    public GameObject specialPower;
    public GameObject asteroid;
    public GameObject specialBulletPickUp;
    

    public Transform player;
    // public float offset;
    float timer;
    float randomtime;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnHealthPickUp", 6f, 15);
        InvokeRepeating("SpawnScorePickUp", 2f, 15);
        InvokeRepeating("SpawnCircle", 4f, 40);
        InvokeRepeating("GunPowerPickUp", 1f, 30);
        InvokeRepeating("SpawnAsteroid", 3f, 10);
        InvokeRepeating("SpawnSpecialBulletPickUp", 5f, 20f);


    }

    void SpawnHealthPickUp()
    { 
        float offset = 500;  
        float positionZ = player.transform.position.z + offset;
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), positionZ);
        Instantiate(health, transform.position + pos, transform.rotation);

    }

    void SpawnScorePickUp()
    {
        float offset = 450;
        float positionZ = player.transform.position.z + offset;
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), positionZ);
        Instantiate(points, transform.position + pos, transform.rotation);

    }

    void SpawnCircle()
    {
        float offset = 800;
        float positionZ = player.transform.position.z + offset;
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), positionZ);
        Instantiate(specialPower, transform.position + pos, transform.rotation);
    }

    void GunPowerPickUp()
    {
        float offset = 400;
        float positionZ = player.transform.position.z + offset;
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), positionZ);
        Instantiate(powerUpGun, transform.position + pos, transform.rotation);

    }

    void SpawnAsteroid()
    {
        float offset = 400;
        float positionZ = player.transform.position.z + offset;
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), positionZ);
        Instantiate(asteroid, transform.position + pos, transform.rotation);
    }

    void SpawnSpecialBulletPickUp()
    {
        float offset = 500;
        float positionZ = player.transform.position.z + offset;
        Vector3 pos = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), positionZ);
        Instantiate(specialBulletPickUp, transform.position + pos, transform.rotation);
    }




}