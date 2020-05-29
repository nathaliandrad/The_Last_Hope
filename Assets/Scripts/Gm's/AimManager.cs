using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{

    public Transform player;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = 250f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y, player.transform.position.z + distance);
        //giving a bit od distance between 2 points
        transform.position = Vector3.Lerp(transform.position, newPosition, 2f * Time.deltaTime);
    }
}
