using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform normalZombie;
        public Transform babyZombie;
        public Transform boss;
        public int amount;
        public float rate;
    }

    public Wave[] waves;
    public static int nextWave;
    public float timeBetweenWaves;
    public float waveCountdown;
    private float searchCountdown;

    public Transform[] spawnPoints;
    private Transform sp;
    private int randomEnemy;
    private bool bossSpawned = false;

    public SpawnState state = SpawnState.COUNTING;
    public static bool finished;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        nextWave = 0;
        searchCountdown = 1f;
        timeBetweenWaves = 15f;
        bossSpawned = false;
        finished = false;
    }

    private void Update()
    {
        // Updates whether wave is completed
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                Shooting.canFire = false;
                WaveCompleted();
            }
            else return;
        }

        // Updates whether wave is activated
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                Shooting.canFire = true;
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    // Method to count down and go to next wave
    private void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            finished = true;
        }
        else nextWave++;
    }

    // Check whether there are still enemies alive
    private bool EnemyIsAlive()
    {
        // Checks after each second to see if there's an enemy
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    // Method to spawn enemies per waves with different enemies
    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        for (int i = 0; i < wave.amount; i++)
        {
            randomEnemy = Random.Range(0, 2);

            switch (nextWave)
            {
                case 0:
                    SpawnEnemy(wave.normalZombie);
                    break;

                case 1:
                    SpawnEnemy(wave.babyZombie);
                    break;

                case 2:
                    if (randomEnemy == 0) SpawnEnemy(wave.normalZombie);
                    else SpawnEnemy(wave.babyZombie);
                    break;

                case 3:
                    if (nextWave == 3 && !bossSpawned)
                    {
                        SpawnEnemy(wave.boss);
                        bossSpawned = true;
                    }
                    else if (randomEnemy == 0) SpawnEnemy(wave.normalZombie);
                    else SpawnEnemy(wave.babyZombie);
                    break;
            }

            yield return new WaitForSeconds(wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    // Method to spawn enemies
    private void SpawnEnemy(Transform enemy)
    {
        // Random spawning op één van de spawnpoints
        sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; 
        Instantiate(enemy, sp.position, Quaternion.identity);
    }
}
