using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    private void Start() {
        // initialize player components
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        // initialize object physics
        Physics.gravity *= gravityModifier;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            // When <spacebar> is pressed, player jumps
            playerAnimator.SetTrigger("Jump_trig");
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        } 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            // when player falls to ground
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            // when player collides with obstacle, game is over
            gameOver = true;
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
            Debug.Log("Game over!");
        }
    }
}
