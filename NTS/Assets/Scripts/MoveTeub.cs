using System;
using System.Collections;
using UnityEngine;
public class MoveTeub : MonoBehaviour
{
    private bool inputJump;
    private bool isGrounded;
    private Rigidbody rb;
    private GameObject player;
    public float speed;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < 15)
        {
            if (!inputJump && isGrounded)
            {
                inputJump = true;
            }

            if ((player.transform.position - transform.position).magnitude > 1)
            {
                transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime * speed;
            }
        }
    }
    private void FixedUpdate()
    {
        if (inputJump && isGrounded)
        {
            rb.AddForce(Vector3.up,ForceMode.Impulse);
            inputJump = false;
            isGrounded = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }
}
