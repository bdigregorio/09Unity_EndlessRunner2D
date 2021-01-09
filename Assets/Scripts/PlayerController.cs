using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;
    
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private float sfxVolume = 0.25f;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private void Start() {
        // initialize player components
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        // initialize object physics
        Physics.gravity *= gravityModifier;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            // When <spacebar> is pressed, player jumps
            playerAudioSource.PlayOneShot(jumpSound, sfxVolume);
            playerAnimator.SetTrigger("Jump_trig");
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
        } 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") && !gameOver) {
            // when player falls to ground
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            // when player collides with obstacle, game is over
            gameOver = true;
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudioSource.PlayOneShot(crashSound, sfxVolume);
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
            Debug.Log("Game over!");
        }
    }
}
