using UnityEngine;

public class AsteroidObj : MonoBehaviour
{
    public float speed = 0.8f;
    public float rotationSpeed = 3f;
    public AudioSource speaker;
    public AudioClip hitSeffect;
    public GameObject effectExp;

    private void FixedUpdate()
    {
        RotateAsteroid();
        MoveAsteroid();
    }

    private void RotateAsteroid()
    {
        transform.Rotate(Vector3.left * rotationSpeed);
    }

    private void MoveAsteroid()
    {
        Vector3 movement = Vector3.back * speed;
        transform.Translate(movement, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") || other.CompareTag("PowerBullet"))
        {
            HandleAsteroidCollision();
        }
    }

    private void HandleAsteroidCollision()
    {
        if (speaker != null && hitSeffect != null)
        {
            speaker.PlayOneShot(hitSeffect, 1);
        }

        if (effectExp != null)
        {
            Instantiate(effectExp, transform.position, transform.rotation);
        }

        GM.score += 30;
        Destroy(gameObject);
    }
}
