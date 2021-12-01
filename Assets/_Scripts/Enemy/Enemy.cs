using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Health and Stuff")]
    public float health;
    public float fullHealth;
    private float noHealth = 0;
    public GameObject healthBar;

    [Header("Stuff")]
    public float damage;
    public Transform player;
    public float speed;

    [Header("Audio")]
    public AudioClip hitClip;
    public AudioSource hitSource;

    private Rigidbody2D rb;
    private Vector3 direction;
    private float angle;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Makes it so the prefab knows who to nomnom
        player = GameObject.FindWithTag("Player").transform; 
        health = fullHealth;
    }

    // Make the enemy follow the player with the correct rotation
    private void Update()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    // Make the enemy move
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    // Method to calculate movement
    public void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * speed * Time.deltaTime));
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        hitSource.PlayOneShot(hitClip);
        health -= damage;

        healthBar.transform.localScale = new Vector3(health / fullHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (health <= noHealth) Die();
    }

    // Execute this when the enemy has 0 HP
    private void Die()
    {
        Destroy(gameObject);
        KillText.count++;
    }
}
