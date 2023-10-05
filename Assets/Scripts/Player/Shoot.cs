using System.Collections;
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
    private AudioSource speaker;

    private void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GM.powerBullet)
            {
                ShootBullet(bulletTestTest, shootSpecialSound);
            }
            else
            {
                ShootBullet(bulletPack, shootSound);
            }

            if (smallAirplane.activeSelf)
            {
                ShootExtraBullets(extraBullet, smallNozzleL);
                ShootExtraBullets(extraBullet, smallNozzleR);
                ShootExtraBullets(extraBullet, smallNozzleL2);
                ShootExtraBullets(extraBullet, smallNozzleR2);
            }
        }
    }

    private void ShootBullet(GameObject bulletType, AudioClip sound)
    {
        Instantiate(bulletType, nozzle.transform.position, Quaternion.identity);
        PlayShootSound(sound);
    }

    private void ShootExtraBullets(GameObject bulletType, GameObject nozzleLocation)
    {
        Instantiate(bulletType, nozzleLocation.transform.position, Quaternion.identity);
    }

    private void PlayShootSound(AudioClip sound)
    {
        speaker.PlayOneShot(sound, 1);
    }
}
