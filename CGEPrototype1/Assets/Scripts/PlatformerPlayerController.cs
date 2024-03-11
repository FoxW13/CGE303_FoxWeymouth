using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    public AudioClip jumpSound;
    private AudioSource playerAudio;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    
    
    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    void FixedUpdate()
    {
        // move the player using RigidBody2D in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
