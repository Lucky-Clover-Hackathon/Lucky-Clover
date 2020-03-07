using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField]
    Transform player;

   
    [SerializeField]
    float aggroRange;
    
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distFromPlayer = Vector2.Distance(transform.position, player.position);

        if (distFromPlayer < aggroRange)
        {
            ChasePlayer();
        }
        else {
            StopChasing();
        }

        print("distFromPlayer" + distFromPlayer);
    }
    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void StopChasing()
    {
        
    }

   
}
