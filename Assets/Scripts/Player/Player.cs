using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Flags to prevent multiple collisions in a short time
    private bool hasEntered;
    private bool hasEnteredAsteroid;
    private bool hasEnteredScore;
    private bool hasEnteredCircle;
    private bool collideWithEnemy;
    private bool bulletCollision;
    private bool hasBossBltEnter;
    private bool hasSmallBltEnter;

    public HealthBar healthBar;
    public int maxHealth = 100;
    private int currentHP;

    public PowerBar powerBar;
    public int maxPower = 100;
    private int currentPower;

    public GameObject smallAirplane;
    public GameObject hitFX;
    public GameObject powerEfxTimer;

    public Text scoreText;

    public GameObject winImage;
    public GameObject looseImage;

    // Audio sources and clips
    public AudioSource speakerMusic;
    public AudioSource speaker;
    public AudioClip hit;
    public AudioClip pickUpSFX;
    public AudioClip circleSFX;
    public AudioClip coinSFX;
    public AudioClip winSound;
    public AudioClip looseSound;

    private void Start()
    {
        speakerMusic.Play(1);
        currentHP = maxHealth;
        healthBar.SetPlayerMaxHealth(maxHealth);
        GM.score = 0;
        currentPower = 0;
        powerBar.SetPowerUp(currentPower);
        smallAirplane.SetActive(false);
        winImage.SetActive(false);
        looseImage.SetActive(false);
        GM.levelBoss = false;
    }

    private void Update()
    {
        ResetCollisionFlags();
        SetScoreText();

        if (currentHP <= 0)
        {
            HandleGameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPack") && !hasEntered)
        {
            HandleHealthPackCollision(other);
        }
        // Handle other collisions here...

        if (other.CompareTag("Diamond"))
        {
            HandleDiamondCollision();
        }
    }

    private void HandleHealthPackCollision(Collider healthPack)
    {
        hasEntered = true;
        speaker.PlayOneShot(pickUpSFX, 1);

        if (currentHP == maxHealth)
        {
            HealthUp(0);
            GM.score += 10;
        }
        else
        {
            HealthUp(20);
        }

        Destroy(healthPack.gameObject);
    }

    // Implement other collision handling methods...

    private void HandleGameOver()
    {
        looseImage.SetActive(true);
        speakerMusic.Stop();
        speaker.PlayOneShot(looseSound, 0.2f);
        StartCoroutine("LooseTime");
    }

    private void ResetCollisionFlags()
    {
        hasEntered = false;
        hasEnteredAsteroid = false;
        hasEnteredCircle = false;
        hasEnteredScore = false;
        collideWithEnemy = false;
        bulletCollision = false;
        hasBossBltEnter = false;
        hasSmallBltEnter = false;
    }

    private void HealthUp(int extraHealth)
    {
        currentHP += extraHealth;
        healthBar.SetPlayerHealth(currentHP);
    }

    // Implement other collision handling methods...

    private void SetScoreText()
    {
        GM.score = Mathf.Max(GM.score, minScore);
        scoreText.text = GM.score.ToString();
    }

    private IEnumerator PowerTimer(float duration)
    {
        Instantiate(powerEfxTimer, transform.position, transform.localRotation);
        currentPower = maxPower;
        powerBar.SetPowerUp(maxPower);

        while (duration > 0)
        {
            smallAirplane.SetActive(true);
            yield return new WaitForSeconds(1);
            duration--;
            currentPower -= 10;
            powerBar.SetPowerUp(currentPower);
        }

        currentPower = 0;
        smallAirplane.SetActive(false);
    }

    private IEnumerator WinTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(0);
    }

    private IEnumerator LooseTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(2);
    }
}
