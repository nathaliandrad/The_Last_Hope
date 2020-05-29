using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject specialEnemy;
    public Transform enemy2;
    public GameObject bar;
    float timer;
    float randomtime;
    public Transform target;

    public AudioSource speaker;
    public AudioClip bossBorn;

    public float offset;
    public float offset2;
    public float specialOffset;

    public bool bossTime;

    int boss;

    public List <GameObject> enemyObjects = new List<GameObject>();
     //Start is called before the first frame update
    void Start()
    {
        offset = 1000f;
        offset2 = 1000f;
        specialOffset = 100f;
        bossTime = false;
        boss = 0;
      // SpawnSpecialEnemy();


        
        InvokeRepeating("Enemy2Spawn", 2, 13.5f);
        Invoke("StopInvokeEnemy2pt1", 50);
        Invoke("StopInvokeEnemy2pt2", 100);
        Invoke("StopInvokeEnemy2pt3", 150);
        Invoke("StopInvoke", 140);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!GM.levelDif2 && !GM.levelDif3 && !GM.levelBoss)
        {
            randomtime = Random.Range(5f, 25f);
            //randomtimeSpecial = Random.Range(10f, 35f);

            timer += Time.deltaTime;
            //anotherTimer += Time.deltaTime;
            if (timer >= randomtime)
            {
                EnemySpawn();
                print("Enemy1");

                timer = 0;
            }
        }
        else if (GM.levelDif2)
        {
            randomtime = Random.Range(3f, 18f);
            //randomtimeSpecial = Random.Range(10f, 35f);

            timer += Time.deltaTime;
            //anotherTimer += Time.deltaTime;
            if (timer >= randomtime)
            {
                EnemySpawn();

                print("Enemy2");
                timer = 0;
            }

        }
        else if (GM.levelDif3)
        {
            randomtime = Random.Range(2f, 10f);
            //randomtimeSpecial = Random.Range(10f, 35f);

            timer += Time.deltaTime;
            //anotherTimer += Time.deltaTime;
            if (timer >= randomtime)
            {
                EnemySpawn();

                print("Enemy3");
                timer = 0;
            }

        }
        else if (GM.levelBoss)
        {
            boss++;
            if (boss == 1)
            {
                SpawnSpecialEnemy();
            }
            //  SpawnSpecialEnemy();
            print("Big boossss");
        }

    }

    public void EnemySpawn()
    {
        //enemy will always respawn from this position z
        float positionZ = target.transform.position.z + offset;
        float randomXnumber = Random.Range(-24, 24);
        // float randomZnumber = Random.Range(200, 2000f);
        float randomYnumber = Random.Range(-24, 24);

        transform.position = new Vector3(randomXnumber, randomYnumber, positionZ);
        Instantiate(enemy, transform.position, transform.rotation);
        //LIST
       // enemyObjects.Add(enemy);

    }

    public void Enemy2Spawn()
    {

            float positionZ = target.transform.position.z + offset;
            float randomXnumber = Random.Range(-24, 24);
            // float randomZnumber = Random.Range(200, 2000f);
            float randomYnumber = Random.Range(-24, 24);

            enemy2.transform.position = new Vector3(randomXnumber, randomYnumber, positionZ);
            Instantiate(enemy2, enemy2.transform.position, enemy2.transform.rotation);

    }

    void StopInvokeEnemy2pt1()
    {
        Debug.Log("starting stage 2");
        CancelInvoke("Enemy2Spawn");
        InvokeRepeating("Enemy2Spawn", 2, 9.5f);
    }
    void StopInvokeEnemy2pt2()
    {
        Debug.Log("starting stage 3");
        CancelInvoke("StopInvokeEnemy2pt1");
        InvokeRepeating("Enemy2Spawn", 2, 6.5f);
    }
    void StopInvokeEnemy2pt3()
    {
        Debug.Log("starting stage 4");
        CancelInvoke("StopInvokeEnemy2pt2");
        InvokeRepeating("Enemy2Spawn", 2, 5);
    }
    void StopInvoke()
    {
        Debug.Log("STOPPED INVOKING");
        CancelInvoke("StopInvokeEnemy2pt3");
        CancelInvoke("StopInvokeEnemy2pt2");
        CancelInvoke("StopInvokeEnemy2pt1");
        CancelInvoke("Enemy2Spawn");

    }

    public void SpawnSpecialEnemy()
    {
        //enemy will always respawn from this position z
        float positionZ = target.transform.position.z + specialOffset;
        float randomXnumber = Random.Range(-25, 25);
        // float randomZnumber = Random.Range(200, 2000f);
        float randomYnumber = Random.Range(-15, 15);

        specialEnemy.transform.position = new Vector3(0, 0, positionZ);
        Instantiate(specialEnemy, specialEnemy.transform.position, specialEnemy.transform.rotation);
        speaker.PlayOneShot(bossBorn, 1);
        //bar.SetActive(true);
    }


}

