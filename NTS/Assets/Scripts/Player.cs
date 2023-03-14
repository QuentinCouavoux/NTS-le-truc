using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal;
    private bool inputJump;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputJump && isGrounded)
        {
            inputJump = Input.GetKeyDown(KeyCode.Space);
        }

        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (inputJump && isGrounded)
        {
            rb.AddForce(Vector3.up*6,ForceMode.Impulse);
            inputJump = false;
            isGrounded = false;
        }

        if (horizontal != 0)
        {
            transform.Translate(Vector3.right*horizontal*Time.deltaTime*7);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
