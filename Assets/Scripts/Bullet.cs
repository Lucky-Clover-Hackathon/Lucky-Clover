using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            //other.Hurt(1);
            
        }
        else if (other.collider.CompareTag("Player"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
