using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

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
    }

    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        yInput = Input.GetAxis("Vertical") * Time.deltaTime;
    }

    private void MovePlayer()
    {
        tf.Translate(xInput * moveSpeed, 0, 0);
    }
}
