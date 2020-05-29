using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCirclePickUp : MonoBehaviour
{
    // public string typePowerUp;
    public float speed;
    float movement;
    float rotation;

    public void Start()
    {
        movement = -0.4f;
        rotation = 7f;
    }

    public void FixedUpdate()
    {


        transform.Rotate(new Vector3(0, 0, rotation));
        transform.Translate(new Vector3(0, 0, movement), Space.World);

        //transform.Translate(new Vector3(0, 0, movement), Space.World );
        // transform.Translate(new Vector3(0, 0, 0), Space.World);
    }
}
