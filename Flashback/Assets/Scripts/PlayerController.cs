using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Move Values")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Player Jump Values")]
    [SerializeField] private float jumpVelocity = 3f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private Transform groundCheckCollider;
    [SerializeField] private LayerMask groundLayer;

    private Transform tf;
    private Rigidbody2D rb2d;
    private float xInput;
    private float yInput;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        MovePlayer();
        ImproveJumpPhysics();
    }


    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        yInput = Input.GetAxis("Vertical") * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            playerJump();
        }
    }

    private bool isGrounded()
    {
        return Physics2D.CircleCast(groundCheckCollider.transform.position, 0.5f, Vector2.down, 0.1f, groundLayer);
    }

    private void playerJump()
    {
        rb2d.velocity = Vector2.up * jumpVelocity;
    }

    private void ImproveJumpPhysics()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void MovePlayer()
    {
        tf.Translate(xInput * moveSpeed, 0, 0);
    }
}
