using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private Enemy enemy;
    private BossState boss;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.gameObject.GetComponent<Enemy>();
        boss = collision.gameObject.GetComponent<BossState>();

        if (enemy != null) enemy.TakeDamage(damage);

        if (boss != null) boss.TakeDamage(damage); 

        Destroy(gameObject);
    }

}
