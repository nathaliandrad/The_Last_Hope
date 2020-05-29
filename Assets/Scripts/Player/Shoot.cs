using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    public GameObject bulletTestTest;
    public GameObject extraBullet;
    public GameObject smallNozzleL, smallNozzleR;
    public GameObject smallNozzleL2, smallNozzleR2;

    

    public GameObject bulletPack, nozzle;


    public GameObject smallAirplane;



    public AudioClip shootSound;
    public AudioClip shootSpecialSound;
    public AudioSource speaker;

    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GM.powerBullet)
            {
                Instantiate(bulletTestTest, nozzle.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                speaker.PlayOneShot(shootSpecialSound, 1);
            }
            else
            Instantiate(bulletPack,nozzle.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            speaker.PlayOneShot(shootSound, 1);



            if (smallAirplane.active)
            {
                Instantiate(extraBullet, smallNozzleL.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(extraBullet, smallNozzleR.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

                Instantiate(extraBullet, smallNozzleL2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                Instantiate(extraBullet, smallNozzleR2.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }

        }



        



    }

}
