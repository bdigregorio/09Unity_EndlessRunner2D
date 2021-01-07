using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
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
