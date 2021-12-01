using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Variables and stuff
    public float speed;
    private float angle;

    public Rigidbody2D rb;
    public WaveSpawner waveSpawner;
    private Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;
    private Vector2 lookDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        // Movement direction
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Makes it so you can look around with your mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Skips count down and starts next wave
        if (Input.GetKeyDown(KeyCode.Q)) waveSpawner.waveCountdown = 0;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        lookDirection = mousePos - rb.position;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
