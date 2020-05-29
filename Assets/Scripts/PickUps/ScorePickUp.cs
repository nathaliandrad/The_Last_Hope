using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickUp : MonoBehaviour
{
    // public string typePowerUp;
    public float speed;
    float movement;
    float rotation;

    public void Start()
    {
        movement = -0.2f;
        rotation = 7f;
    }

    public void FixedUpdate()
    {


        transform.Rotate(new Vector3(0, rotation, 0));
        transform.Translate(new Vector3(0, 0, movement), Space.World);

        //transform.Translate(new Vector3(0, 0, movement), Space.World );
        // transform.Translate(new Vector3(0, 0, 0), Space.World);
    }
}
