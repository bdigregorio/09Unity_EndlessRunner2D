using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftParallax : MonoBehaviour
{
    public float speed = 17f;
    private PlayerController playerController;

    private void Start() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update() {
        if (playerController.gameOver == false) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
