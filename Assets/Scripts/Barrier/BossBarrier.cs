using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreLayerCollision(13, 14);
        if (other.gameObject.CompareTag("Player"))
        {
             GM.levelDif2 = false;
            GM.levelDif3 = false;
            GM.levelBoss = true;
            print("BossLevel");
        }
    }
}
