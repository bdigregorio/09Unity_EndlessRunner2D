using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private float floatForce = 0.6f;
    private float bounceForce = 675;
    private float cielingForce = 4;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRigidbody;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private float sfxVolume = 0.5f;
    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

    private float yMaxBounds = 14f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver) {
            playerRigidbody.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        Vector3 playerPosition = transform.position;
        // Prevent player from getting too high
        if (playerPosition.y > yMaxBounds) {
            transform.position = new Vector3(playerPosition.x, yMaxBounds, playerPosition.z);
            playerRigidbody.AddForce(Vector3.down * cielingForce, ForceMode.Impulse);
        }     
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, sfxVolume);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, do fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, sfxVolume);
            Destroy(other.gameObject);

        }

        // if player collides with ground, do bounce
        else if (other.gameObject.CompareTag("Ground")) {
            playerAudio.PlayOneShot(bounceSound, sfxVolume);
            playerRigidbody.AddForce(Vector3.up * bounceForce);
        }
    }

}
