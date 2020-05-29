using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimManager : MonoBehaviour
{
    //AimAtEnemy[] lookAtEnemies;
    //List<GameObject> enemiesList = new List<GameObject>();
    //public GameObject closestEnemy;
    //public float maxRange = 1000;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    lookAtEnemies = GetComponentsInChildren<AimAtEnemy>();
    //    EnemyManager[] enemiesInScene = FindObjectsOfType<EnemyManager>();
    //    foreach (EnemyManager enemy in enemiesInScene)
    //    {
    //        enemiesList.Add(enemy.gameObject);
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{


    //    ClosestEnemy();
    //}

    //void ClosestEnemy()
    //{
    //    float range = maxRange;
    //    foreach (GameObject enemyGameObject in enemiesList)
    //    {
    //        float dist = Vector3.Distance(enemyGameObject.transform.position, transform.position);
    //        if (dist < range)
    //        {
    //            range = dist;
    //            closestEnemy = enemyGameObject;
    //        }
    //    }

    //    foreach (AimAtEnemy lookAtEnemy in lookAtEnemies)
    //    {
    //        lookAtEnemy.enemy = closestEnemy;
    //    }
    //}
}
