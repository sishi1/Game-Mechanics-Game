using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("Health Stuff")]
    public float health;
    public float fullHealth;
    private float noHealth = 0;
    public GameObject healthBar;

    [Header("Boss objects")]
    public GameObject rockPrefab;
    public Transform zombiePrefab;
    public Transform babyZombiePrefab;
    public Transform firePoint;
    public Transform player;

    [Header("Boss Stuff")]
    public float damage;
    public float speed;
    public float force;
    public float fireRate;
    private float startFiring;
    public float distanceBetweenPlayer;
    public float spawnTime;
    public static int killWorth;

    [Header("Audio")]
    public AudioClip hitClip;
    public AudioSource hitSource;

    private Rigidbody2D rb;
    private Vector3 direction;
    private float angle;
    private Vector2 movement;
    private int randomEnemy;
    private bool canSpawn;
    private float timer;

    public enum Status
    {
        Idle, Chasing, Spawning, Shooting, HealingUp
    }

    Status status = Status.Idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform; //Makes it so the prefab knows who to nomnom
        health = fullHealth;
        startFiring = fireRate;
        timer = spawnTime;
        canSpawn = true;
    }

    private void Update()
    {
        MoveBoss();

        timer -= Time.deltaTime;

        if (timer <= 0) canSpawn = true;    

        ExecuteBehavior();
    }

    // Switch case statement for the boss behavior
    private void ExecuteBehavior()
    {
        switch (status)
        {
            case Status.Idle:
                IdleBehavior();
                break;

            case Status.Chasing:
                ChasingBehavior();
                break;

            case Status.Shooting:
                ShootingBehavior();
                break;

            case Status.Spawning:
                SummonMinionsBehavior();
                break;
        }
    }

    // Method to make the boss react on certain variables
    private void IdleBehavior()
    {
        if (Vector2.Distance(transform.position, player.position) >= distanceBetweenPlayer)
        {
            if (canSpawn && health <= fullHealth/2) status = Status.Spawning;
            else status = Status.Shooting;
        }
        else status = Status.Chasing;
    }

    // Chase the player
    private void ChasingBehavior()
    {
        speed = 2.5f;
        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));

        if (Vector2.Distance(transform.position, player.position) >= distanceBetweenPlayer) status = Status.Idle;
    }

    // Method to make the boss shoot a nice rock at the player
    private void ShootingBehavior()
    {
        if (Vector2.Distance(transform.position, player.position) <= distanceBetweenPlayer) status = Status.Idle;

        if (startFiring <= 0)
        {
            startFiring = fireRate;
            Instantiate(rockPrefab, firePoint.position, Quaternion.identity);
        }
        else startFiring -= Time.deltaTime;
    }

    // Spawn minions to aid the boss
    private void SummonMinionsBehavior()
    {
        for (int i = 0; i < 2; i++)
        {
            randomEnemy = Random.Range(0, 2);
            if (randomEnemy == 0) SpawnMinions(zombiePrefab);
            else SpawnMinions(babyZombiePrefab);
        }

        canSpawn = false;
        timer = spawnTime;
        status = Status.Idle;
    }

    private void MoveBoss()
    {
        // Look at the player's direction
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        // Move it 
        rb.MovePosition((Vector2)transform.position + (movement * speed * Time.deltaTime));
    }

    // Method to spawning minions
    private void SpawnMinions(Transform zombie)
    {
        Instantiate(zombie, firePoint.position, Quaternion.identity);
    }

    // Method to inflict damage
    public void TakeDamage(float damage)
    {
        hitSource.PlayOneShot(hitClip);
        health -= damage;

        healthBar.transform.localScale = new Vector3(health / fullHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (health <= noHealth) Die();
    }

    // Execute this when the boss has 0 HP
    private void Die()
    {
        Destroy(gameObject);
        KillText.count += killWorth;
    }
}
