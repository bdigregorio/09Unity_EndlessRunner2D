using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    // Start is called before the first frame update
    private void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        } 
    }

    private void OnCollisionEnter(Collision collision) {
        isOnGround = true;
    }
}
