using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public GameObject rock;
    public float fireRate;
    private float startShooting;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startShooting = fireRate; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            transform.position = this.transform.position;
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        if (startShooting <= 0)
        {
            Instantiate(rock, transform.position, Quaternion.identity);
            startShooting = fireRate;
        }
        else startShooting -= Time.deltaTime;
    }
}
