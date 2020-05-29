using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public Transform target;


    void Start()
    {
    
    }

    void FixedUpdate()
    {
       //setting position of camera
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
        //giving a bit od distance between 2 points
        transform.position = Vector3.Lerp(transform.position, newPosition, 1f * Time.deltaTime);

   
    }
}
