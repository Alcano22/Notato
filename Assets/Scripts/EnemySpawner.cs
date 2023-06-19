using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Vector2 topLeftCorner, bottomRightCorner;
    [SerializeField] float spawnDelay;
    [SerializeField] float playerSafeRadius;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform player;

    float nextSpawnTime = 0f;

    void Update()
    {
        if (bottomRightCorner.x <= topLeftCorner.x || topLeftCorner.y <= bottomRightCorner.y)
        {
            Debug.LogError("Bottom right corner cannot be larger than top left corner!");
            enabled = false;
        }

        if (nextSpawnTime <= Time.time)
        {
            nextSpawnTime = Time.time + spawnDelay;

            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

        Vector2 spawnPos = new Vector2(Random.Range(topLeftCorner.x, bottomRightCorner.x), Random.Range(bottomRightCorner.y, topLeftCorner.y));
        float playerDist = Vector2.Distance(player.position, spawnPos);
        if (playerDist < playerSafeRadius)
        {
            SpawnEnemy();
            return;
        }

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
