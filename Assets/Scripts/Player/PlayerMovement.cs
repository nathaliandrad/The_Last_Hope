using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float rotationPlane = 15.0f;
    [SerializeField] private float maxLimitLeft = -25f;
    [SerializeField] private float maxLimitRight = 25;
    [SerializeField] private float maxLimitDown = -25f;
    [SerializeField] private float maxLimitTop = 25f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float speedY = 0.9f;
    [SerializeField] private float turbineRot = 1f;

    [Header("Game Objects")]
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject cam;
    [SerializeField] private Transform turbineLeft;
    [SerializeField] private Transform turbineRight;

    private float angles;
    private float anglesXX;
    
    private void Start()
    {
        anglesXX = 0;
    }

    private void FixedUpdate()
    {
        MoveForward();
        Rotate();
    }

    private void MoveForward()
    {
        transform.Translate(new Vector3(0, 0, movementSpeed) * Time.deltaTime);
    }

    private void Rotate()
    {
        // Rotation for turning left
        if (Input.GetKey(KeyCode.A) && (transform.position.x > maxLimitLeft))
        {
            RotateLeft();
        }
        // Rotation for turning right
        else if (Input.GetKey(KeyCode.D) && (transform.position.x < maxLimitRight))
        {
            RotateRight();
        }
        // Reset rotation when not turning
        else
        {
            ResetRotation();
        }

        // Rotation for moving up
        if (Input.GetKey(KeyCode.W) && (transform.position.y < maxLimitTop))
        {
            RotateUp();
        }
        // Rotation for moving down
        else if (Input.GetKey(KeyCode.S) && (transform.position.y > maxLimitDown))
        {
            RotateDown();
        }
        // Reset vertical rotation when not moving up/down
        else
        {
            ResetVerticalRotation();
        }
    }

    private void RotateLeft()
    {
        turbineLeft.Rotate(new Vector3(0, -turbineRot, 0), Space.Self);
        turbineRight.Rotate(new Vector3(0, -turbineRot, 0), Space.Self);
        transform.Translate(new Vector3(-speed, 0, 0), Space.World);
        cam.transform.Translate(new Vector3(-speed / 2, 0, 0), Space.World);
        if (angles < 0) angles = 0;
        if (angles < 30) angles += 10f;
        transform.eulerAngles = new Vector3(0, 0, angles);
    }

    private void RotateRight()
    {
        turbineLeft.Rotate(new Vector3(0, turbineRot, 0), Space.Self);
        turbineRight.Rotate(new Vector3(0, turbineRot, 0), Space.Self);
        transform.Translate(new Vector3(speed, 0, 0), Space.World);
        cam.transform.Translate(new Vector3(speed / 2, 0, 0), Space.World);
        if (angles > 0) angles = 0;
        if (angles > -30) angles -= 10f;
        transform.eulerAngles = new Vector3(0, 0, angles);
    }

    private void ResetRotation()
    {
        transform.eulerAngles = Vector3.zero;
        turbineLeft.localRotation = Quaternion.identity;
        turbineRight.localRotation = Quaternion.identity;
    }

    private void RotateUp()
    {
        turbineLeft.Rotate(new Vector3(-turbineRot, 0, 0), Space.Self);
        turbineRight.Rotate(new Vector3(-turbineRot, 0, 0), Space.Self);
        transform.Translate(new Vector3(0, speedY, 0), Space.World);
        cam.transform.Translate(new Vector3(0, speed / 1.5f, 0), Space.World);
        transform.eulerAngles = new Vector3(-rotationPlane, 0, 0);
    }

    private void RotateDown()
    {
        turbineLeft.Rotate(new Vector3(turbineRot, 0, 0), Space.Self);
        turbineRight.Rotate(new Vector3(turbineRot, 0, 0), Space.Self);
        transform.Translate(new Vector3(0, -speedY, 0), Space.World);
        cam.transform.Translate(new Vector3(0, -speed / 1.5f, 0), Space.World);
        transform.eulerAngles = new Vector3(rotationPlane, 0, 0);
    }

    private void ResetVerticalRotation()
    {
        turbineLeft.localRotation = Quaternion.identity;
        turbineRight.localRotation = Quaternion.identity;
    }
}
