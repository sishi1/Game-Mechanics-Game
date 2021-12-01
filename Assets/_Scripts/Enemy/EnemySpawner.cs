using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    private float randomX, randomY;
    private Vector2 whereToSpawn;
    private float nextSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomX = Random.Range(0.6f, 25.5f);
            randomY = Random.Range(17.5f, 5.5f);
            whereToSpawn = new Vector2(randomX, randomY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
    }
}
