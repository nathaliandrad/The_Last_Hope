using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float movementSpeed = 20f;
    float rotationPlane = 15.0f;
    public float angles;
    public float anglesXX;

    float maxLimitLeft = -25f;
    float maxLimitRight = 25;
    float maxLimitDown = -25f;
    float maxLimitTop = 25f;

    public bool movingHoriLeft = false;
    public bool movingHoriRight = false;

    public float speed;
    public float speedY;

    public GameObject leftWall, rightWall;
    public GameObject cam;

    public Transform turbineLeft;
    public Transform turbineRight;

    public float turbineRot;

   // public float angles;
    private Vector3 offset;


    void Start()
    {
        turbineRot = 1f;
        anglesXX = 0;
        speed = 1f;
        speedY = 0.9f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.Translate(new Vector3(0, 0, movementSpeed) * Time.deltaTime);
        //moving left
        if (Input.GetKey(KeyCode.A) && (transform.position.x > maxLimitLeft))
        {
            turbineLeft.transform.Rotate(new Vector3(0, -turbineRot, 0),Space.Self);
            turbineRight.transform.Rotate(new Vector3(0, -turbineRot, 0), Space.Self);

            transform.Translate(new Vector3(-speed, 0, 0), Space.World);
           
            cam.transform.Translate(new Vector3(-speed / 2, 0, 0), Space.World);
            RotateLeft();
            
        }
        //moving right
        if (Input.GetKey(KeyCode.D) && (transform.position.x < maxLimitRight))
        {
            turbineLeft.transform.Rotate(new Vector3(0, turbineRot, 0), Space.Self);
            turbineRight.transform.Rotate(new Vector3(0, turbineRot, 0), Space.Self);
            transform.Translate(new Vector3(speed, 0, 0), Space.World);
            cam.transform.Translate(new Vector3(speed / 2, 0, 0), Space.World);
            RotateRight();
        }
        //checking rotation
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            turbineLeft.transform.Rotate(new Vector3(0, 0, 0), Space.Self);
            turbineRight.transform.Rotate(new Vector3(0, 0, 0), Space.Self);

        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            //  transform.eulerAngles = new Vector3(0, 0, 0);
            turbineLeft.transform.Rotate(new Vector3(0, 0, 0), Space.Self);
            turbineRight.transform.Rotate(new Vector3(0, 0, 0), Space.Self);

        }

        //moving up
        if (Input.GetKey(KeyCode.W) && (transform.position.y < maxLimitTop))
        {

            turbineLeft.transform.Rotate(new Vector3(-turbineRot, 0, 0), Space.Self);
            turbineRight.transform.Rotate(new Vector3(-turbineRot, 0, 0), Space.Self);
            transform.Translate(new Vector3(0, speedY, 0), Space.World);
            cam.transform.Translate(new Vector3(0, speed / 1.5f, 0), Space.World);
            RotateUp();
        }//moving down
        if (Input.GetKey(KeyCode.S) && (transform.position.y > maxLimitDown))
        {

            turbineLeft.transform.Rotate(new Vector3(turbineRot, 0, 0), Space.Self);
            turbineRight.transform.Rotate(new Vector3(turbineRot, 0, 0), Space.Self);
            // transform.eulerAngles = new Vector3(anglesXX, 0, 0);
            transform.Translate(new Vector3(0, -speedY, 0) , Space.World);
            cam.transform.Translate(new Vector3(0, -speed / 1.5f, 0), Space.World);
            RotateDown();
        }

    }


    void RotateUp()
    {

        transform.eulerAngles = new Vector3(-rotationPlane, 0, 0);
    }
    void RotateDown()
    {

        transform.eulerAngles = new Vector3(rotationPlane, 0, 0);
    }
    void RotateLeft()
    {
        if (angles < 0) //if my angle is facing right - pob back to 0
        {
            angles = 0;
        }
        if (angles < 30) //limit my angles to 25f
        {
            angles += 10f;
        }

        transform.eulerAngles = new Vector3(0, 0, angles);
    }

    void RotateLeftUp()
    {
        transform.eulerAngles = new Vector3(angles, 0, angles);
    }



    void RotateRight()
    {
        if (angles > 0)
        {
            angles = 0;
        }
        if (angles > -30)
        {
            angles -= 10f;
        }

        transform.eulerAngles = new Vector3(0, 0, angles);
    }
}
