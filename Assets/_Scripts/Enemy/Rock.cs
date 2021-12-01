using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int damage;
    public float speed;

    private Transform thePlayer;
    private PlayerHealth player;
    private Vector2 target;

    private void Start()
    {
        thePlayer = GameObject.FindWithTag("Player").transform;
        target = new Vector2(thePlayer.position.x, thePlayer.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y) Destroy(gameObject); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.takeDamage(damage);
        }

        Destroy(gameObject);
    }
}
