using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class MoveTeub : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < 5)
        {
            transform.position += (player.transform.position - transform.position).normalized * Time.deltaTime * speed;
        }
    }
}
