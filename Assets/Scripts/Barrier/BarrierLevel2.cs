using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierLevel2 : MonoBehaviour
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
            GM.levelDif2 = true;
            print("level 2");
        }
    }
}
