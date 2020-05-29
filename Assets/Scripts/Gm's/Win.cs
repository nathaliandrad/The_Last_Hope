using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    public GameObject winImage;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(-90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Rotate(new Vector3(0, 0, -1), Space.Self);

    }

}
