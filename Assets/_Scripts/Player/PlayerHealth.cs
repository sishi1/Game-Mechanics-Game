using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health and Stuff")]
    public float health;
    public float fullHealth = 100;
    private float noHealth = 0;
    public static bool death;
    public Image healthBar;

    private Enemy enemy;
    private BossState boss;
    private Vector2 difference;

    [Header("Audio")]
    public AudioClip heartClip;
    public AudioSource heartSource;

    void Start()
    {
        health = fullHealth;
        death = false;
    }

    // Method to take damage 
    public void takeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / fullHealth;

        if (health <= noHealth) death = true;
    }

    // Checks whether the player gets hit 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.gameObject.GetComponent<Enemy>();
        boss = collision.gameObject.GetComponent<BossState>();

        if (enemy != null)
        {
            heartSource.PlayOneShot(heartClip);
            takeDamage(enemy.damage);
            // Push back
            difference = (transform.position - collision.transform.position);
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }

        if (boss != null)
        {
            heartSource.PlayOneShot(heartClip);
            takeDamage(boss.damage);
            // Push back
            difference = (transform.position - collision.transform.position);
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
