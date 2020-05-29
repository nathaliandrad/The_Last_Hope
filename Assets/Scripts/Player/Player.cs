using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //way of avoiding an item to collide multiple times at the same time
    public bool hasEntered;
    public bool hasEnteredAsteroid;
    public bool hasEnteredScore;
    public bool hasEnteredCircle;
    public bool collideWithEnemy;
    public bool bulletCollision;
    public bool hasBossBltEnter;
    public bool hasSmallBltEnter;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHP;

    public PowerBar powerBar;
    public int maxPower = 100;
    public int currentPower;
    public int minScore;
   
    public GameObject smallAirplane;
    public GameObject hitFX;
    public GameObject powerEfxTimer;


    public Text scoreText;

    public GameObject winImage;
    public GameObject LooseImage;

    //sounds
    public AudioSource speakerMusic;
    public AudioSource speaker;

   
    public AudioClip hit;

    public AudioClip pickUpSFX;
    public AudioClip circleSFX;
    public AudioClip coinSFX;
    public AudioClip winSound;
    public AudioClip looseSound;

    void Start()
    {
        //speakerMusic = GetComponent<AudioSource>();

        speakerMusic.Play(1);

        currentHP = maxHealth;
        healthBar.SetPlayerMaxHealth(maxHealth);
        GM.score = 0;
        currentPower = 0;
        powerBar.SetPowerUp(currentPower);
        //powerBar.Se(maxHealth);
        smallAirplane.SetActive(false);
        winImage.SetActive(false);
        LooseImage.SetActive(false);
        GM.levelBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        hasEntered = false;
        hasEnteredAsteroid = false;
        hasEnteredCircle = false;
        hasEnteredScore = false;
        collideWithEnemy = false;
        bulletCollision = false;
        hasBossBltEnter = false;
        hasSmallBltEnter =false;

        
    SetScoreText();

        if (currentHP <= 0)
        {
            LooseImage.SetActive(true);
            speakerMusic.Stop();
            speaker.PlayOneShot(looseSound, 0.2f);
          
            StartCoroutine("LooseTime");
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("HealthPack") && !hasEntered)
        { 
            hasEntered = true;
            speaker.PlayOneShot(pickUpSFX, 1);
           if(currentHP == maxHealth)
            {
                HealthUp(0);
                GM.score += 10;
                Debug.Log("COLLIDING WITH HEALTH PACK");

            }
            else
            {
                HealthUp(20);
                
            }
            Destroy(other.gameObject);


        }
        if (other.gameObject.CompareTag("GunPower"))
        {
            GM.score += 50;
            speaker.PlayOneShot(pickUpSFX, 1);
            StartCoroutine("PowerTimer");
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH GUN PACK");

        }

        if (other.gameObject.CompareTag("PowerBullet"))
        {
            GM.score += 50;
            speaker.PlayOneShot(pickUpSFX, 1);
            // currentPower = maxPower;
            // powerBar.SetPowerUp(maxPower);
            // InvokeRepeating("PowerBarTimer", 1f, 1f);
            // smallAirplane.SetActive(true);    
            // StartCoroutine(Delay());
            StartCoroutine("PowerTimerGun");
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH UP GUN POWER PACK");

        }

        if (other.gameObject.CompareTag("Asteroid") && !hasEnteredAsteroid)
        {
            Instantiate(hitFX, other.transform.position, other.transform.rotation);
            speaker.PlayOneShot(hit, 1);
            GM.score -= 50;
            hasEnteredAsteroid = true;
            TakeDamage(10);
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH ASTEROID PACK");
           

        }

        if (other.gameObject.CompareTag("ScoreUp") && !hasEnteredScore)
        {
            speaker.PlayOneShot(coinSFX, 1);
            GM.score += 300;
            hasEnteredScore = true;
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH SCORE UP PACK");
        }

        if (other.gameObject.CompareTag("SpecialCircle") && !hasEnteredCircle)
        {
            speaker.PlayOneShot(circleSFX, 1);
            GM.score += 500;
            hasEnteredCircle = true;
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH CIRCLE PACK");
        }


        if (other.gameObject.CompareTag("Enemy") && !collideWithEnemy)
        {
            Instantiate(hitFX, other.transform.position, other.transform.rotation);
            speaker.PlayOneShot(hit, 1);
            TakeDamage(15);
            GM.score -= 100;
            collideWithEnemy = true;
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH ENEMY PACK");
        }



        if (other.gameObject.CompareTag("EnemyBullet") && !bulletCollision)
        {
            Instantiate(hitFX, other.transform.position, other.transform.rotation);
            speaker.PlayOneShot(hit, 1);
            TakeDamage(10);
            GM.score -= 20;
            bulletCollision = true;
            Destroy(other.gameObject);
            print("ENEMY BULLET COLLINDG");
            Debug.Log("COLLIDING WITH ENEMY BULLET PACK");
        }

        if (other.gameObject.CompareTag("BossBullet") && !hasBossBltEnter)
        {
            Instantiate(hitFX, other.transform.position, other.transform.rotation);
            speaker.PlayOneShot(hit, 1);
            TakeDamage(20);
            GM.score -= 20;
            hasBossBltEnter = true;
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH BOSS BULET PACK");
        }
        if (other.gameObject.CompareTag("SmallBossBullet") && !hasSmallBltEnter)
        {
            Instantiate(hitFX, other.transform.position, other.transform.rotation);
            speaker.PlayOneShot(hit, 1);
            TakeDamage(10);
            GM.score -= 20;
            hasSmallBltEnter = true;
            Destroy(other.gameObject);
            Debug.Log("COLLIDING WITH SMALL BOSS BULLET PACK");

        }

        if (other.gameObject.CompareTag("Diamond"))
        {
            winImage.SetActive(true);
            speakerMusic.Stop();
            speaker.PlayOneShot(winSound, 0.2f);
           // speaker.Stop();
            StartCoroutine("WinTime");
        }


    }



    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        healthBar.SetPlayerHealth(currentHP);
    }

    public void HealthUp(int extraHealth)
    {
        currentHP += extraHealth;
        healthBar.SetPlayerHealth(currentHP);
    }

    public IEnumerator PowerTimer()
    {
        float timer= 10;
        Instantiate(powerEfxTimer, transform.position, transform.localRotation);
        powerEfxTimer.transform.position = transform.position;
        currentPower = maxPower;
        powerBar.SetPowerUp(maxPower);
        
        while (timer > 0)
        {
            smallAirplane.SetActive(true);
            yield return new WaitForSeconds(1);
            timer--;
            currentPower -= 10;
            powerBar.SetPowerUp(currentPower);
            
        }
        int minPower = 0;
        currentPower = minPower;
        smallAirplane.SetActive(false);

    }

    public IEnumerator PowerTimerGun()
    {
        float timer = 10;
        Instantiate(powerEfxTimer, transform.position, transform.localRotation);
        powerEfxTimer.transform.position = transform.position;
        currentPower = maxPower;
        powerBar.SetPowerUp(maxPower);

        while (timer > 0)
        {
            GM.powerBullet = true;
            yield return new WaitForSeconds(1);
            timer--;
            currentPower -= 10;
            powerBar.SetPowerUp(currentPower);

        }
        int minPower = 0;
        currentPower = minPower;
        //smallAirplane.SetActive(false);
        GM.powerBullet = false;

    }

    public IEnumerator WinTime()
    {
        float timer =  5;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
        SceneManager.LoadScene(0);
     


    }


    public IEnumerator LooseTime()
    {
        float timer = 3;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
        SceneManager.LoadScene(2);
      


    }


    // ----- TEXT  ------
    void SetScoreText()
    {
        if (GM.score <= 0)
        {
            GM.score = 0;
        }
        scoreText.text = "" + GM.score.ToString();
    }

}
