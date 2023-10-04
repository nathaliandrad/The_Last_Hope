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

    public float offset = 1000f;
    public float offset2 = 1000f;
    public float specialOffset = 100f;

    public bool bossTime;

    int boss;

    public List<GameObject> enemyObjects = new List<GameObject>();

    void Start()
    {
        offset = 1000f;
        offset2 = 1000f;
        specialOffset = 100f;
        bossTime = false;
        boss = 0;

        InvokeRepeating("Enemy2Spawn", 2, 13.5f);
        Invoke("StopInvokeEnemy2pt1", 50);
        Invoke("StopInvokeEnemy2pt2", 100);
        Invoke("StopInvokeEnemy2pt3", 150);
        Invoke("StopInvoke", 140);
    }

    void FixedUpdate()
    {
        if (GM.levelBoss)
        {
            HandleBossLevel();
        }
        else if (GM.levelDif3)
        {
            HandleLevelDif3();
        }
        else if (GM.levelDif2)
        {
            HandleLevelDif2();
        }
        else
        {
            HandleDefaultLevel();
        }
    }
    
    void HandleDefaultLevel()
    {
        randomtime = Random.Range(5f, 25f);
        timer += Time.deltaTime;
        if (timer >= randomtime)
        {
            EnemySpawn();
            timer = 0;
        }
    }
    
    void HandleLevelDif2()
    {
        randomtime = Random.Range(3f, 18f);
        timer += Time.deltaTime;
        if (timer >= randomtime)
        {
            EnemySpawn();
            timer = 0;
        }
    }
    
    void HandleLevelDif3()
    {
        randomtime = Random.Range(2f, 10f);
        timer += Time.deltaTime;
        if (timer >= randomtime)
        {
            EnemySpawn();
            timer = 0;
        }
    }
    
    void HandleBossLevel()
    {
        if (boss == 0)
        {
            SpawnSpecialEnemy();
            boss++;
        }
    }

    public void EnemySpawn()
    {
        float positionZ = target.transform.position.z + offset;
        float randomXnumber = Random.Range(-24, 24);
        float randomYnumber = Random.Range(-24, 24);

        transform.position = new Vector3(randomXnumber, randomYnumber, positionZ);
        Instantiate(enemy, transform.position, transform.rotation);
    }

    public void Enemy2Spawn()
    {
        float positionZ = target.transform.position.z + offset;
        float randomXnumber = Random.Range(-24, 24);
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
        float positionZ = target.transform.position.z + specialOffset;
        float randomXnumber = Random.Range(-25, 25);
        float randomYnumber = Random.Range(-15, 15);

        specialEnemy.transform.position = new Vector3(0, 0, positionZ);
        Instantiate(specialEnemy, specialEnemy.transform.position, specialEnemy.transform.rotation);
        speaker.PlayOneShot(bossBorn, 1);
    }
}
