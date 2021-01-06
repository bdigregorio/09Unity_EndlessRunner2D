using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject obstacle;
    private float minSpawnInterval = 0.65f;
    private float maxSpawnInterval = 2.25f;
    private float startDelay = 1;
    private float nextSpawnTime = 0;
    private Vector3 spawnPosition = new Vector3(35, 0, 0);

    private void Start()    {
        Invoke(nameof(SpawnObstacle), startDelay);
    }

    private void SpawnObstacle() {
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);

        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke(nameof(SpawnObstacle), nextSpawnTime);
    }
}
