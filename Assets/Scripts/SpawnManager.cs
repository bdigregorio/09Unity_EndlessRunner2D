using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject obstacle;
    private PlayerController playerController;
    private float minSpawnInterval = 0.6f;
    private float maxSpawnInterval = 2.15f;
    private float startDelay = 1;
    private float nextSpawnTime = 0;
    private Vector3 spawnPosition = new Vector3(38, 0, 0);

    private void Start()    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        // schedule initial obstacle spawn
        Invoke(nameof(SpawnObstacle), startDelay);
    }

    private void SpawnObstacle() {
        if (playerController.gameOver == false) {
            // spawn an obstacle
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);

            // schedule next obstacle spawn
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            Invoke(nameof(SpawnObstacle), nextSpawnTime);
        }
    }
}
