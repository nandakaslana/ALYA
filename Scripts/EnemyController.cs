using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 
    public Collider2D areaBatas; // Batas

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //  posisi player berada dalam area batas
        if (areaBatas == null || areaBatas.OverlapPoint(player.position))
        {
            // Hitung arah menuju player
            Vector2 direction = (player.position - transform.position).normalized;

            // Gerakkan enemy ke arah player
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            // hentikan enemy jika diluar batas
            rb.velocity = Vector2.zero;
        }
    }
}